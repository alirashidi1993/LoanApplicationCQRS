using Framework.Domain;
using Framework.Domain.Exceptions;
using LoanApplications.Domain.Contracts;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public partial class LoanApplication : AggregateRoot
    {

        public int ApplicantId { get; private set; }
        public int PaybackMonths { get; private set; }
        public int Amount { get; private set; }
        public string Description { get; private set; }
        public LoanApplicationState State { get; private set; }
        public LoanApplication(int applicantId, int payBackMonths, int amount, string description)
        {
            Causes(new LoanRequested(applicantId, payBackMonths, amount, description));   
        }
        
        public void Reject(string reason)
        {
            if(State.CanReject())
            {
                Causes(new LoanApplicationRejected(Id, reason));
            }
            else
            {
                throw new InvalidStateException(State,"Reject");
            }
        }
        public void Accept()
        {
            if(State.CanAccept())
            {
                Causes(new LoanApplicationAccepted(Id));
            }
            else
            {
                throw new InvalidStateException(State, "Accept");
            }
        }
    }
}
