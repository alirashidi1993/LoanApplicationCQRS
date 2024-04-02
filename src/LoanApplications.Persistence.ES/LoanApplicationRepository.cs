using Framework.Domain;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Persistence.ES
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly IEventSourceRepository<LoanApplication> eventSourceRepository;

        public LoanApplicationRepository(IEventSourceRepository<LoanApplication> eventSourceRepository)
        {
            this.eventSourceRepository = eventSourceRepository;
        }
        public Task Add(LoanApplication loanApplication)
        { 
            return eventSourceRepository.AppendEvents(loanApplication);
        }

        public Task<LoanApplication> GetById(Guid id)
        {
            var res = eventSourceRepository.GetById(id);
            return res;
        } 

        public Task Update(LoanApplication loanApplication)
        {
            return eventSourceRepository.AppendEvents(loanApplication);
        }
    }
}