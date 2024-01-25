namespace Shared.DataTransferObjects
{
    public class ProductDto
    {
        public required string Name { get; set; }

        public Guid DepartnentId { get; set; }
    }
}
