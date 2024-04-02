using Framework.Core.Events;

namespace LoanApplications.Projections.Sql.Framework
{
    public class FakeEventBus : IEventBus
    {
        public Task Publish<T>(T eventToPublish) where T : IEvent
        {
            return Task.CompletedTask;
        }
    }
}
