using Framework.Domain;

namespace LoanApplications.Domain.Contracts
{
    public class LoanApplicationAccepted : DomainEvent
    {
        public LoanApplicationAccepted(Guid loanApplicationId)
        {
            LoanApplicationId = loanApplicationId;
        }
        public Guid LoanApplicationId { get; private set; }
    }
}
