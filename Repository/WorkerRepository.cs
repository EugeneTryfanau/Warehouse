using Contracts;
using Entities.Models;

namespace Repository
{
    public class WorkerRepository : RepositoryBase<Worker>, IWorkerRepository
    {
        public WorkerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateWorker(Worker worker)
        {
            Create(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            Delete(worker);
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return GetAll().OrderBy(w => w.LastName).ToList();
        }

        public Worker? GetWorker(Guid workerId)
        {
            return GetByCondition(w => w.Id.Equals(workerId)).SingleOrDefault();
        }

        public void UpdateWorker(Worker worker)
        {
            Update(worker);
        }
    }
}
