namespace LoanApplications.Domain.Model.LoanApplications
{
    public interface ILoanApplicationRepository
    {
        Task Add(LoanApplication loanApplication);
        Task Update(LoanApplication loanApplication);
        Task<LoanApplication> GetById(Guid id);
    }
}
