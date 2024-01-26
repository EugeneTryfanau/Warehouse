namespace Shared.DataTransferObjects
{
    public record DepartmentForCreationDto(string Name, ICollection<ProductForCreationDto> Products, ICollection<WorkerForCreationDto> Workers);
}
