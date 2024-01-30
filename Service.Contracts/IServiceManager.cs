namespace Service.Contracts
{
    public interface IServiceManager
    {
        IDepartmentService DepartmentService { get; }
        IWorkerService WorkerService { get; }
        IProductService ProductService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
