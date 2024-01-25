namespace Shared.DataTransferObjects
{
    public record DepartmentDto(string Name, ICollection<ProductDto>? Products, ICollection<WorkerDto>? Workers);
}
