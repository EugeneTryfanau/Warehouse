using Entities.Models;

namespace Contracts
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorker(Guid workerId);
        void CreateWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(Worker worker);
    }
}
