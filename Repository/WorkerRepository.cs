using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await GetAll().OrderBy(w => w.LastName).ToListAsync();
        }

        public async Task<Worker?> GetWorkerAsync(Guid workerId)
        {
            return await GetByCondition(w => w.Id.Equals(workerId)).SingleOrDefaultAsync();
        }

        public void UpdateWorker(Worker worker)
        {
            Update(worker);
        }
    }
}
