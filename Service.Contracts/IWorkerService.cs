using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IWorkerService
    {
        Task<IEnumerable<WorkerDto>> GetAllWorkersAsync();
        Task<WorkerDto> GetWorkerAsync(Guid workerId);
        Task<WorkerDto> CreateWorkerAsync(WorkerForCreationDto workerForCreationDto);
        Task UpdateWorkerAsync(Guid workerId, WorkerForUpdateDto workerForUpdateDto);
        Task DeleteWorkerAsync(Guid workerId);

        Task<(WorkerForUpdateDto workerToPatch, Worker workerEntity)> GetWorkerForPatchAsync(Guid workerId);
        Task SaveChangesForPatchAsync(WorkerForUpdateDto workerToPatch, Worker workerEntity);
    }
}
