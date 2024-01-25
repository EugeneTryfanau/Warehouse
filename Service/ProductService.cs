using AutoMapper;
using Contracts;
using Serilog;
using Service.Contracts;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, ILogger logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
