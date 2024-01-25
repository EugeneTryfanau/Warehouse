namespace Entities.Exceptions
{
    public sealed class WorkerNotFoundException : NotFoundException
    {
        public WorkerNotFoundException(Guid id) : base($"The worker with id: {id} doesn't exist in the database.") { }
    }
}
