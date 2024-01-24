using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IWorkerService> _workerService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager));
            _workerService = new Lazy<IWorkerService>(() => new WorkerService(repositoryManager));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
        }

        public IDepartmentService DepartmentService => _departmentService.Value;
        public IWorkerService WorkerService => _workerService.Value;
        public IProductService ProductService => _productService.Value;
    }
}
