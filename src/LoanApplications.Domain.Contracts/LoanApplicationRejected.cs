using Framework.Domain;

namespace LoanApplications.Domain.Contracts
{
    public class LoanApplicationRejected : DomainEvent
    {
        public LoanApplicationRejected(Guid loanApplicationId, string reason)
        {
            LoanApplicationId = loanApplicationId;
            Reason = reason;
        }

        public Guid LoanApplicationId { get; private set; }
        public string Reason { get; private set; }
    }
}
