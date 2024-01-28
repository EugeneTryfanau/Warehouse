using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace WarehouseTests
{
    public class WorkerServiceFake : IWorkerService
    {
        public readonly List<WorkerDto> _workers;

        public WorkerServiceFake()
        {
            _workers = new List<WorkerDto>()
            {
                new WorkerDto(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a"), "TestWorkerFirstName0", "TestWorkerLastName0", new List<DepartmentDto>()),
                new WorkerDto(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5b"), "TestWorkerFirstName1", "TestWorkerLastName1", new List<DepartmentDto>()),
                new WorkerDto(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5c"), "TestWorkerFirstName2", "TestWorkerLastName2", new List<DepartmentDto>()),
            };
        }

        public async Task<WorkerDto> CreateWorkerAsync(WorkerForCreationDto workerForCreationDto)
        {
            var worker = new WorkerDto(Guid.NewGuid(), workerForCreationDto.FirstName, workerForCreationDto.LastName, new List<DepartmentDto>());
            _workers.Add(worker);
            return worker;
        }

        public async Task DeleteWorkerAsync(Guid workerId)
        {
            var existing = _workers.First(a => a.Id == workerId);
            _workers.Remove(existing);
        }

        public async Task<IEnumerable<WorkerDto>> GetAllWorkersAsync()
        {
            return _workers;
        }

        public async Task<WorkerDto> GetWorkerAsync(Guid workerId)
        {
            return _workers.FirstOrDefault(a => a.Id == workerId);
        }

        public async Task<(WorkerForUpdateDto workerToPatch, Worker workerEntity)> GetWorkerForPatchAsync(Guid workerId)
        {
            var workerDb = _workers.Where(d => d.Id == workerId).SingleOrDefault();
            Worker worker = new Worker() { Id = workerId, FirstName = workerDb.FirstName, LastName = workerDb.LastName, Departments = new List<Department>() };
            var workerToPatch = new WorkerForUpdateDto(workerDb.FirstName, workerDb.LastName, new List<DepartmentForUpdateDto>());
            return (workerToPatch, worker);
        }

        public async Task SaveChangesForPatchAsync(WorkerForUpdateDto workerToPatch, Worker workerEntity)
        {
            
        }

        public async Task UpdateWorkerAsync(Guid workerId, WorkerForUpdateDto workerForUpdateDto)
        {
            var workerDb = _workers.Where(d => d.Id == workerId).SingleOrDefault();
            var workerForUpdate = new WorkerDto(workerId, workerForUpdateDto.FirstName, workerForUpdateDto.LastName, new List<DepartmentDto>());
            _workers.Remove(workerDb);
            _workers.Add(workerForUpdate);
        }
    }
}
