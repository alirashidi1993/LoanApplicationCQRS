namespace Framework.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private List<DomainEvent> _uncommittedEvents;

        protected AggregateRoot() 
        {
            _uncommittedEvents = new List<DomainEvent>();
        }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();
        public long Version { get; protected set; }

        public void Causes(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
            Apply(@event);
        }

        public virtual void Apply(DomainEvent @event)
        {
            Version++;
        }
    }
}
