﻿using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartment(Guid departmentId);
        DepartmentDto CreateDepartment(DepartmentForCreationDto departmentForCreationDto);
        void UpdateDepartment(Guid departmentId, DepartmentForUpdateDto departmentForUpdateDto);
        void DeleteDepartment(Guid departmentId);
    }
}
