using AutoMapper;
using Contracts;
using Serilog;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IWorkerService> _workerService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, ILogger logger, IMapper mapper)
        {
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, logger, mapper));
            _workerService = new Lazy<IWorkerService>(() => new WorkerService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
        }

        public IDepartmentService DepartmentService => _departmentService.Value;
        public IWorkerService WorkerService => _workerService.Value;
        public IProductService ProductService => _productService.Value;
    }
}
