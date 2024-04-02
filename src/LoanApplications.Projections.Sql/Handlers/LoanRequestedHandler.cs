using Framework.Core.Events;
using LoanApplications.Domain.Contracts;

namespace LoanApplications.Projections.Sql.Handlers
{
    public class LoanRequestedHandler : IEventHandler<LoanRequested>
    {

        public Task Handle(LoanRequested @event)
        {
            return Task.CompletedTask;
        }
    }
}
