using FluentValidation.Results;
using Omini.Opme.Be.Application.Abstractions.Messaging;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Enums;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Domain.Transactions;
using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Application.Commands;

public record CreateQuotationCommand : ICommand<Quotation>
{
    public string Number { get; set; }
    public Guid PatientId { get; set; }
    public Guid PhysicianId { get; set; }
    public PayingSourceType PayingSourceType { get; set; }
    public Guid PayingSourceId { get; set; }
    public Guid HospitalId { get; set; }
    public Guid InsuranceCompanyId { get; set; }
    public Guid InternalSpecialistId { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<CreateQuotationItemCommand> Items { get; set; }

    public class CreateQuotationItemCommand
    {
        public int? LineOrder { get; set; }
        public Guid ItemId { get; set; }
        public string ItemCode { get; set; }
        public string AnvisaCode { get; set; }
        public DateTime AnvisaDueDate { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
    }

    public class CreateQuotationCommandHandler : ICommandHandler<CreateQuotationCommand, Quotation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IQuotationRepository _quotationRepository;

        public CreateQuotationCommandHandler(IUnitOfWork unitOfWork,
                                             IHospitalRepository hospitalRepository,
                                             IPatientRepository patientRepository,
                                             IInsuranceCompanyRepository insuranceCompanyRepository,
                                             IPhysicianRepository physicianRepository,
                                             IQuotationRepository quotationRepository)
        {
            _unitOfWork = unitOfWork;
            _hospitalRepository = hospitalRepository;
            _patientRepository = patientRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _physicianRepository = physicianRepository;
            _quotationRepository = quotationRepository;
        }

        public async Task<Result<Quotation, ValidationResult>> Handle(CreateQuotationCommand request, CancellationToken cancellationToken)
        {
            var validationFailures = new List<ValidationFailure>();
            var hospital = await _hospitalRepository.GetById(request.HospitalId, cancellationToken);
            if (hospital is null)
            {
                validationFailures.Add(new ValidationFailure("Hospital Id", "Invalid Id"));
            }

            var patient = await _patientRepository.GetById(request.PatientId, cancellationToken);
            if (patient is null)
            {
                validationFailures.Add(new ValidationFailure("Patient Id", "Invalid Id"));
            }

            var insuranceCompany = await _insuranceCompanyRepository.GetById(request.InsuranceCompanyId, cancellationToken);
            if (insuranceCompany is null)
            {
                validationFailures.Add(new ValidationFailure("InsuranceCompany Id", "Invalid Id"));
            }

            var physician = await _physicianRepository.GetById(request.PhysicianId, cancellationToken);
            if (physician is null)
            {
                validationFailures.Add(new ValidationFailure("Physician Id", "Invalid Id"));
            }

            if (validationFailures.Any())
            {
                return new ValidationResult(validationFailures);
            }

            var quotation = new Quotation()
            {
                Number = request.Number,
                PatientId = request.PatientId,
                PhysicianId = request.PhysicianId,
                PayingSourceType = request.PayingSourceType,
                PayingSourceId = request.PayingSourceId,
                HospitalId = request.HospitalId,
                InsuranceCompanyId = request.InsuranceCompanyId,
                InternalSpecialistId = request.InternalSpecialistId,
                DueDate = request.DueDate.ToUniversalTime(),
                Items = request.Items.Select((item, index) => new QuotationItem
                {
                    LineId = index,
                    LineOrder = item.LineOrder ?? index,
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    AnvisaCode = item.AnvisaCode,
                    AnvisaDueDate = item.AnvisaDueDate.ToUniversalTime(),
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    ItemTotal = item.Quantity * item.UnitPrice,
                }).ToList()
            };

            await _quotationRepository.Add(quotation, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return quotation;
        }
    }
}