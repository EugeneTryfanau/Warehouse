using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Worker
    {
        [Column("WorkerId")]
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public virtual ICollection<Department>? Departments { get; set; }
    }
}
