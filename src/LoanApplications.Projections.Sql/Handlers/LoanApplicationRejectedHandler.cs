using Framework.Core.Events;
using LoanApplications.Domain.Contracts;

namespace LoanApplications.Projections.Sql.Handlers
{
    public class LoanApplicationRejectedHandler : IEventHandler<LoanApplicationRejected>
    {

        public Task Handle(LoanApplicationRejected @event)
        {
            return Task.CompletedTask;
        }
    }
}
