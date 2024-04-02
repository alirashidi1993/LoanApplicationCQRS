using EventStore.Client;
using Framework.Core;
using Framework.Core.Events;
using Framework.Persistence.ES;
using LoanApplications.Domain.Contracts;
using LoanApplications.Projections.Sql.Framework;
using LoanApplications.Projections.Sql.Settings;

namespace LoanApplications.Projections.Sql
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        
        private readonly ICursor cursor;
        private readonly IEventTypeResolver eventTypeResolver;
        private readonly IEventBus eventBus;

        public Worker(
            ILogger<Worker> logger,
            ICursor cursor,
            IEventTypeResolver eventTypeResolver,
            IEventBus eventBus)
        {
            _logger = logger;
            this.cursor = cursor;
            this.eventTypeResolver = eventTypeResolver;
            this.eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            

            eventTypeResolver.AddTypesFromAssembly(typeof(LoanRequested).Assembly);

            var settings = EventStoreClientSettings.Create("esdb://eventstore:2113?tls=false");

            var client = new EventStoreClient(settings);

            await client.SubscribeToAllAsync(
                FromAll.Start,
                EventAppeared);

            _logger.LogInformation($"Connected to eventstore [{DateTime.Now:yyyy:MM:dd HH:mm:ss}]");
        }

        private async Task EventAppeared(
            StreamSubscription subscription,
            ResolvedEvent @event,
            CancellationToken token)
        {
            if (!@event.OriginalEvent.EventType.StartsWith('$'))
            {
                var domainEvent = DomainEventFactory.CreateFrom(@event, eventTypeResolver);
                if (domainEvent == null)
                {
                    _logger.LogWarning(
                        "No type registered for event type " +
                        @event.OriginalEvent.EventType);
                }
                else
                {
                    _logger.LogInformation(
                        $"Received Event {@event.OriginalEvent.EventType}-[{DateTime.Now:yyyy:MM:dd HH:mm:ss}]");

                    await eventBus.Publish(domainEvent);
                }
            }
        }
    }
}