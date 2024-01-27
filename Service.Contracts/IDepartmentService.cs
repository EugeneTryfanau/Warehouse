using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentAsync(Guid departmentId);
        Task<DepartmentDto> CreateDepartmentAsync(DepartmentForCreationDto departmentForCreationDto);
        Task UpdateDepartmentAsync(Guid departmentId, DepartmentForUpdateDto departmentForUpdateDto);
        Task DeleteDepartmentAsync(Guid departmentId);

        Task<(DepartmentForUpdateDto departmentToPatch, Department departmentEntity)> GetDepartmentForPatchAsync(Guid departmentId);
        Task SaveChangesForPatchAsync(DepartmentForUpdateDto departmentToPatch, Department departmentEntity);
    }
}
