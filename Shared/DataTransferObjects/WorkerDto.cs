namespace Shared.DataTransferObjects
{
    public record WorkerDto(Guid Id, string FirstName, string LastName, ICollection<DepartmentDto>? Departments);
}
