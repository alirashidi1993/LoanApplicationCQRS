using Framework.Core.Events;

namespace Framework.Domain
{
    public abstract class DomainEvent: IEvent
    {
        protected DomainEvent()
        {
            PublishDateTime = DateTime.Now;
            EventId = Guid.NewGuid();
        }
        public Guid EventId { get; private set;}
        public DateTime PublishDateTime { get; private set; }
    }
}
