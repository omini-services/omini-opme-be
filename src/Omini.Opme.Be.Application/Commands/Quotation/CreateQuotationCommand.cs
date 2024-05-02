using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Enums;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Domain.Transactions;
using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Application.Commands;

public record CreateQuotationCommand : IRequest<Result<Quotation, ValidationException>>
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
        public double ItemTotal { get; set; }
        public double Quantity { get; set; }
    }

    public class CreateQuotationCommandHandler : IRequestHandler<CreateQuotationCommand, Result<Quotation, ValidationException>>
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

        public async Task<Result<Quotation, ValidationException>> Handle(CreateQuotationCommand request, CancellationToken cancellationToken)
        {
            var validationFailures = new List<ValidationFailure>();
            var hospital = await _hospitalRepository.GetById(request.HospitalId);
            if (hospital is null)
            {
                validationFailures.Add(new ValidationFailure("Hospital Id", "Invalid Id"));
            }

            var patient = await _patientRepository.GetById(request.PatientId);
            if (patient is null)
            {
                validationFailures.Add(new ValidationFailure("Patient Id", "Invalid Id"));
            }

            var insuranceCompany = await _insuranceCompanyRepository.GetById(request.InsuranceCompanyId);
            if (insuranceCompany is null)
            {
                validationFailures.Add(new ValidationFailure("InsuranceCompany Id", "Invalid Id"));
            }

            var physician = await _physicianRepository.GetById(request.PhysicianId);
            if (physician is null)
            {
                validationFailures.Add(new ValidationFailure("Physician Id", "Invalid Id"));
            }

            if (validationFailures.Any())
            {
                return new ValidationException("Invalid quotation values", validationFailures);
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
                DueDate = request.DueDate,
                Items = request.Items.Select((item, index) => new QuotationItem
                {
                    LineId = index,
                    LineOrder = item.LineOrder ?? index,
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    AnvisaCode = item.AnvisaCode,
                    AnvisaDueDate = item.AnvisaDueDate,
                    UnitPrice = item.UnitPrice,
                    ItemTotal = item.ItemTotal,
                    Quantity = item.Quantity,
                }).ToList()
            };

            await _quotationRepository.Add(quotation);
            await _unitOfWork.Commit();

            return quotation;
        }
    }
}