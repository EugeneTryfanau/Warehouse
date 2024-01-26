namespace Shared.DataTransferObjects
{
    public record DepartmentForUpdateDto(string Name, ICollection<ProductForCreationDto> Products, ICollection<WorkerForCreationDto> Workers);
}
