namespace Shared.DataTransferObjects
{
    public record DepartmentDto(Guid Id, string Name, ICollection<ProductDto>? Products, ICollection<WorkerDto>? Workers);
}
