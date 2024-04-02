using Framework.Domain;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public partial class LoanApplication
    {
        public override void Apply(DomainEvent @event)
        {
            base.Apply(@event);
            When((dynamic)@event);
        }
        private void When(LoanRequested @event)
        {
            ApplicantId = @event.ApplicantId;
            PaybackMonths = @event.PaybackMonths;
            Description = @event.Description;
            State = new InProgress();
        }
    }
}
