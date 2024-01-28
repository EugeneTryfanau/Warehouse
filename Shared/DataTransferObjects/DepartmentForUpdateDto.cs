namespace Shared.DataTransferObjects
{
    public record DepartmentForUpdateDto(string Name, ICollection<ProductForUpdateDto> Products, ICollection<WorkerForUpdateDto> Workers);
}
