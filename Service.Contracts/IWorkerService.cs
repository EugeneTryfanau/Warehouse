using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IWorkerService
    {
        IEnumerable<WorkerDto> GetAllWorkers();
        WorkerDto GetWorker(Guid workerId);
        WorkerDto CreateWorker(WorkerForCreationDto workerForCreationDto);
        void UpdateWorker(Guid workerId, WorkerForUpdateDto workerForUpdateDto);
        void DeleteWorker(Guid workerId);

        (WorkerForUpdateDto workerToPatch, Worker workerEntity) GetWorkerForPatch(Guid workerId);
        void SaveChangesForPatch(WorkerForUpdateDto workerToPatch, Worker workerEntity);
    }
}
