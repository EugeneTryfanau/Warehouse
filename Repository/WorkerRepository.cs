using Contracts;
using Entities.Models;

namespace Repository
{
    public class WorkerRepository : RepositoryBase<Worker>, IWorkerRepository
    {
        public WorkerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


    }
}
