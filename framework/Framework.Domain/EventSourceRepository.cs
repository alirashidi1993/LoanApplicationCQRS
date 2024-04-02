namespace Framework.Domain
{
    public class EventSourceRepository<T> : IEventSourceRepository<T> where T : AggregateRoot
    {
        private readonly IEventStore eventStore;
        private readonly IAggregateFactory aggregateFactory;

        public EventSourceRepository(IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            this.eventStore = eventStore;
            this.aggregateFactory = aggregateFactory;
        }
        public async Task AppendEvents(T aggregate)
        {
            var events = aggregate.GetUncommittedEvents();

            await eventStore.AppendEvents(GetStreamName(aggregate.Id), events);
        }

        public async Task<T> GetById(Guid id)
        {
            var listOfEvents = await eventStore.GetEventsOfStream(GetStreamName(id));

            return aggregateFactory.Create<T>(listOfEvents);
        }

        private string GetStreamName(Guid id)
        {
            var type = typeof(T).Name;
            return $"{type}-{id}";
        }
    }
}
