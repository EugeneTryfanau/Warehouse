using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Department
    {
        [Column("DepartmentId")]
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

        public virtual ICollection<Worker>? Workers { get; set; }
    }
}
