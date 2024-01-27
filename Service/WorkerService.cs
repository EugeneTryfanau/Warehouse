using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Serilog;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public WorkerService(IRepositoryManager repositoryManager, ILogger logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<WorkerDto> CreateWorkerAsync(WorkerForCreationDto workerForCreationDto)
        {
            var worker = _mapper.Map<Worker>(workerForCreationDto);

            _repositoryManager.Worker.CreateWorker(worker);
            await _repositoryManager.SaveAsync();

            var workerDto = _mapper.Map<WorkerDto>(worker);
            return workerDto;
        }

        public async Task<IEnumerable<WorkerDto>> GetAllWorkersAsync()
        {
            var workers = await _repositoryManager.Worker.GetAllWorkersAsync();
            var workersDto = _mapper.Map<IEnumerable<WorkerDto>>(workers);

            return workersDto;
        }

        public async Task<WorkerDto> GetWorkerAsync(Guid workerId)
        {
            var worker = await _repositoryManager.Worker.GetWorkerAsync(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            var workerDto = _mapper.Map<WorkerDto>(worker);
            return workerDto;
        }

        public async Task UpdateWorkerAsync(Guid workerId, WorkerForUpdateDto workerForUpdateDto)
        {
            var worker = await _repositoryManager.Worker.GetWorkerAsync(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            _mapper.Map(workerForUpdateDto, worker);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteWorkerAsync(Guid workerId)
        {
            var worker = await _repositoryManager.Worker.GetWorkerAsync(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            _repositoryManager.Worker.DeleteWorker(worker);
            await _repositoryManager.SaveAsync();
        }

        public async Task<(WorkerForUpdateDto workerToPatch, Worker workerEntity)> GetWorkerForPatchAsync(Guid workerId)
        {
            var worker = await _repositoryManager.Worker.GetWorkerAsync(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);

            var workerToPatch = _mapper.Map<WorkerForUpdateDto>(worker);
            return (workerToPatch, worker);
        }

        public async Task SaveChangesForPatchAsync(WorkerForUpdateDto workerToPatch, Worker workerEntity)
        {
            _mapper.Map(workerToPatch, workerEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
