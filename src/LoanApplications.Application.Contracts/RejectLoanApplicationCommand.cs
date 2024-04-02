using Framework.Application;

namespace LoanApplications.Application.Contracts
{
    public class RejectLoanApplicationCommand :Command
    {
        public Guid LoanApplicationId { get; set; }
        public string Reason { get; set; }
    }
    public class AcceptLoanApplicationCommand:Command
    {
        public Guid LoanApplicationId { get; set; }
    }
}
