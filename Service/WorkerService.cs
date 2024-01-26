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

        public WorkerDto CreateWorker(WorkerForCreationDto workerForCreationDto)
        {
            var worker = _mapper.Map<Worker>(workerForCreationDto);

            _repositoryManager.Worker.CreateWorker(worker);
            _repositoryManager.Save();

            var workerDto = _mapper.Map<WorkerDto>(worker);
            return workerDto;
        }

        public IEnumerable<WorkerDto> GetAllWorkers()
        {
            var workers = _repositoryManager.Worker.GetAllWorkers();
            var workersDto = _mapper.Map<IEnumerable<WorkerDto>>(workers);

            return workersDto;
        }

        public WorkerDto GetWorker(Guid workerId)
        {
            var worker = _repositoryManager.Worker.GetWorker(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            var workerDto = _mapper.Map<WorkerDto>(worker);
            return workerDto;
        }

        public void UpdateWorker(Guid workerId, WorkerForUpdateDto workerForUpdateDto)
        {
            var worker = _repositoryManager.Worker.GetWorker(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            _mapper.Map(workerForUpdateDto, worker);
            _repositoryManager.Save();
        }

        public void DeleteWorker(Guid workerId)
        {
            var worker = _repositoryManager.Worker.GetWorker(workerId);
            if (worker is null)
                throw new WorkerNotFoundException(workerId);
            _repositoryManager.Worker.DeleteWorker(worker);
            _repositoryManager.Save();
        }
    }
}
