using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record WorkerDto(Guid Id, string FirstName, string LastName, ICollection<Department>? Departments);
}
