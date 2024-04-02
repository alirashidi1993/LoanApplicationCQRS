using Framework.Core.Events;
using LoanApplications.Domain.Contracts;

namespace LoanApplications.Projections.Sql.Handlers
{
    public class LoanApplicationAcceptedHandler : IEventHandler<LoanApplicationAccepted>
    {

        public Task Handle(LoanApplicationAccepted @event)
        {
            return Task.CompletedTask;
        }
    }
}
