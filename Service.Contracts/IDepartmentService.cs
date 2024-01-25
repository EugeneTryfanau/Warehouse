using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartment(Guid departmentId);
    }
}
