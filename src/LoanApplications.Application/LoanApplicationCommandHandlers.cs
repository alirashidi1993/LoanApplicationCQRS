using Framework.Application;
using LoanApplications.Application.Contracts;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Application
{
    public class LoanApplicationCommandHandlers : 
        ICommandHandler<RequestLoanCommand>,
        ICommandHandler<AcceptLoanApplicationCommand>,
        ICommandHandler<RejectLoanApplicationCommand>
    {
        private readonly ILoanApplicationRepository repository;

        public LoanApplicationCommandHandlers(ILoanApplicationRepository repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RequestLoanCommand request, CancellationToken cancellationToken)
        {
            var loanApplication =
                new LoanApplication(request.ApplicantId, request.PaybackMonths, request.Amount, request.Description);

            await repository.Add(loanApplication);
        }

        public async Task Handle(AcceptLoanApplicationCommand request, CancellationToken cancellationToken)
        {
            var loanApplication =await  repository.GetById(request.LoanApplicationId);
            loanApplication.Accept();
            await repository.Update(loanApplication);
        }

        public async Task Handle(RejectLoanApplicationCommand request, CancellationToken cancellationToken)
        {
            var loanApplication = await repository.GetById(request.LoanApplicationId);
            loanApplication.Reject(request.Reason);
            await repository.Update(loanApplication);
        }
    }
}
