using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Worker
    {
        [Column("WorkerId")]
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public ICollection<Department>? Departments { get; set; }
    }
}
