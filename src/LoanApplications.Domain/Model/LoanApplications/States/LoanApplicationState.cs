namespace LoanApplications.Domain.Model.LoanApplications.States
{
    public abstract class LoanApplicationState
    {
        public virtual bool CanReject()=>false;
        public virtual bool CanAccept()=>false;
    }
    public class InProgress : LoanApplicationState
    {
        public override bool CanAccept() => true;

        public override bool CanReject() => true;
        
    }
    public class Accepted : LoanApplicationState
    {
        public override bool CanAccept() => false;
        public override bool CanReject() => false;
        
    }
}
