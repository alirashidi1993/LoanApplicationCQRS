using Framework.Domain;

namespace LoanApplications.Domain.Contracts
{
    public class LoanRequested : DomainEvent
    {
        public LoanRequested(int applicantId, int payBackMonths, int amount, string description)
        {
            ApplicantId = applicantId;
            PaybackMonths = payBackMonths;
            Amount = amount;
            Description = description;
        }

        public int ApplicantId { get; private set; }
        public int PaybackMonths { get; private set; }
        public int Amount { get; private set; }
        public string Description { get; private set; }
    }
}
