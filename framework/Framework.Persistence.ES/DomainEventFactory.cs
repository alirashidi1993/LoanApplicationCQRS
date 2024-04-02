
using EventStore.Client;
using Framework.Core;
using Framework.Domain;
using Newtonsoft.Json;
using System.Text;

namespace Framework.Persistence.ES
{
    internal static class DomainEventFactory
    {
        public static List<DomainEvent> CreateFrom(
            List<ResolvedEvent> resolvedEvents,
            IEventTypeResolver eventTypeResolver)
        {
            var domainEvents = new List<DomainEvent>();
            resolvedEvents.ForEach(e =>
            {
                var type = eventTypeResolver.GetType(e.Event.EventType);
                var body = Encoding.UTF8.GetString(e.Event.Data.ToArray());
                var @event= (DomainEvent)JsonConvert.DeserializeObject(body,type);
                domainEvents.Add(@event);

            });
            return domainEvents;
        }
        public static DomainEvent CreateFrom(
            ResolvedEvent resolvedEvent, 
            IEventTypeResolver eventTypeResolver)
        {
            var type = eventTypeResolver.GetType(resolvedEvent.Event.EventType);
            var body = Encoding.UTF8.GetString(resolvedEvent.Event.Data.ToArray());
            var @event = (DomainEvent)JsonConvert.DeserializeObject(body,type);
            return @event;
        }
    }
}