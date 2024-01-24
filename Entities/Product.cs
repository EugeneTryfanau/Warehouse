using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }

        public required string Name { get; set; }


        [ForeignKey(nameof(Department))]
        public Guid DepartnentId { get; set; }
        public Department? Department { get; set; }
    }
}
