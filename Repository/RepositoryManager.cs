using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IWorkerRepository> _workerRepository;
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(repositoryContext));
            _workerRepository = new Lazy<IWorkerRepository>(() => new WorkerRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        }

        public IDepartmentRepository Department => _departmentRepository.Value;
        public IWorkerRepository Worker => _workerRepository.Value;
        public IProductRepository Product => _productRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
