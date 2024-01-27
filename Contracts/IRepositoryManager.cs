namespace Contracts
{
    public interface IRepositoryManager
    {
        IDepartmentRepository Department { get; }
        IWorkerRepository Worker { get; }
        IProductRepository Product { get; }

        Task SaveAsync();
    }
}
