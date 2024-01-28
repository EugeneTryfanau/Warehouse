namespace Shared.DataTransferObjects
{
    public record WorkerForUpdateDto(string FirstName, string LastName, ICollection<DepartmentForUpdateDto> Departments);
}
