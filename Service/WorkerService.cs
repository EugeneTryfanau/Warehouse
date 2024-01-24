using Contracts;
using Service.Contracts;

namespace Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public WorkerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
