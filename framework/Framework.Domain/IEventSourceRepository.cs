namespace Framework.Domain
{
    public interface IEventSourceRepository<T>
    {
        Task<T> GetById(Guid id);
        Task AppendEvents(T aggregateRoot);
    }
}