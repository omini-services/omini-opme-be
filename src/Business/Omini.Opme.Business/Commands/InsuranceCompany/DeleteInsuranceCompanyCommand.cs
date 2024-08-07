using FluentValidation.Results;
using Omini.Opme.Business.Abstractions.Messaging;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Domain.Transactions;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Business.Commands;

public record DeleteInsuranceCompanyCommand : ICommand<InsuranceCompany>
{
    public string Code { get; init; }

    public class DeleteInsuranceCompanyCommandHandler : ICommandHandler<DeleteInsuranceCompanyCommand, InsuranceCompany>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;

        public DeleteInsuranceCompanyCommandHandler(IUnitOfWork unitOfWork, IInsuranceCompanyRepository insuranceCompanyRepository)
        {
            _unitOfWork = unitOfWork;
            _insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task<Result<InsuranceCompany, ValidationResult>> Handle(DeleteInsuranceCompanyCommand request, CancellationToken cancellationToken)
        {
            var insuranceCompany = await _insuranceCompanyRepository.GetByCode(request.Code, cancellationToken);
            if (insuranceCompany is null)
            {
                return new ValidationResult([new ValidationFailure(nameof(request.Code), "Invalid code")]);
            }

            _insuranceCompanyRepository.Delete(insuranceCompany, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return insuranceCompany;
        }
    }
}