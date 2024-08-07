using FluentValidation.Results;
using Omini.Opme.Business.Abstractions.Messaging;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Domain.Transactions;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Business.Commands;

public record DeletePatientCommand : ICommand<Patient>
{
    public string Code { get; init; }

    public class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand, Patient>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork, IPatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }

        public async Task<Result<Patient, ValidationResult>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByCode(request.Code, cancellationToken);
            if (patient is null)
            {
                return new ValidationResult([new ValidationFailure(nameof(request.Code), "Invalid code")]);
            }

            _patientRepository.Delete(patient, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return patient;
        }
    }
}