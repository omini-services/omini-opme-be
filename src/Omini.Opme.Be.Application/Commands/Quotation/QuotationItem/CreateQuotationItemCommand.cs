using FluentValidation.Results;
using Omini.Opme.Be.Application.Abstractions.Messaging;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Domain.Transactions;
using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Application.Commands;

public record CreateQuotationItemCommand : ICommand<Quotation>
{
    public Guid QuotationId { get; set; }
    public int? LineOrder { get; set; }
    public string ItemCode { get; set; }
    public double UnitPrice { get; set; }
    public double ItemTotal { get; set; }
    public double Quantity { get; set; }

    public class CreateQuotationItemCommandHandler : ICommandHandler<CreateQuotationItemCommand, Quotation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;
        private readonly IQuotationRepository _quotationRepository;

        public CreateQuotationItemCommandHandler(IUnitOfWork unitOfWork,
                                                 IItemRepository itemRepository,
                                                 IQuotationRepository quotationRepository)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
            _quotationRepository = quotationRepository;
        }

        public async Task<Result<Quotation, ValidationResult>> Handle(CreateQuotationItemCommand request, CancellationToken cancellationToken)
        {
            var validationFailures = new List<ValidationFailure>();
            var quotation = await _quotationRepository.GetById(request.QuotationId, cancellationToken);
            if (quotation is null)
            {
                validationFailures.Add(new ValidationFailure(nameof(request.QuotationId), "Invalid Id"));
            }

            var item = await _itemRepository.GetByCode(request.ItemCode, cancellationToken);
            if (item is null)
            {
                validationFailures.Add(new ValidationFailure(nameof(request.ItemCode), "Invalid ItemCode"));
            }

            if (validationFailures.Any())
            {
                return new ValidationResult(validationFailures);
            }

            var items = quotation.Items;
            var newLineId = items.Max(i => i.LineId) + 1;

            var newItem = new QuotationItem
            {
                LineId = newLineId,
                LineOrder = request.LineOrder ?? newLineId,
                ItemId = item.Id,
                ItemCode = request.ItemCode,
                ItemName = item.Name,
                ReferenceCode = "ref",
                AnvisaCode = item.AnvisaCode ?? string.Empty,
                AnvisaDueDate = item.AnvisaDueDate?.ToUniversalTime() ?? DateTime.Now.ToUniversalTime(),
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity,
                ItemTotal = request.Quantity * request.UnitPrice,
            };

            quotation.Total = quotation.Items.Sum(p => p.ItemTotal);

            items.Add(newItem);

            _quotationRepository.Update(quotation, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return quotation;
        }
    }
}