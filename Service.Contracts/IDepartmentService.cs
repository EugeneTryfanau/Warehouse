using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
    }
}
