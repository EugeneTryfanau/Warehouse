using Service.Contracts;

namespace WarehouseTests
{
    public class ServiceManagerFake : IServiceManager
    {
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IWorkerService> _workerService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManagerFake()
        {
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentServiceFake());
            _workerService = new Lazy<IWorkerService>(() => new WorkerServiceFake());
            _productService = new Lazy<IProductService>(() => new ProductServiceFake());
        }

        public IDepartmentService DepartmentService => _departmentService.Value;
        public IWorkerService WorkerService => _workerService.Value;
        public IProductService ProductService => _productService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
