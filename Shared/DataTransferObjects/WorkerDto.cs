using Entities.Models;

namespace Shared.DataTransferObjects
{
    public class WorkerDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public ICollection<Department>? Departments { get; set; }
    }
}
