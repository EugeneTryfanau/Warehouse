namespace Shared.DataTransferObjects
{
    public record DepartmentForCreationDto(string DepartmentName, ICollection<ProductForCreationDto> Products, ICollection<WorkerForCreationDto> Workers);
}
