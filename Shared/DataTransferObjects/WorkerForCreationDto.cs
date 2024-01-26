namespace Shared.DataTransferObjects
{
    public record WorkerForCreationDto(string FirstName, string LastName, ICollection<DepartmentForCreationDto> Departments);
}
