using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WorkerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
    }
}
