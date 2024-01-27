using Entities.Models;

namespace Contracts
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetAllWorkersAsync();
        Task<Worker?> GetWorkerAsync(Guid workerId);
        void CreateWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(Worker worker);
    }
}
