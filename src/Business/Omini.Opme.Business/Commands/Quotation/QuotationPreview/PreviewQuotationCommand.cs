using FluentValidation.Results;
using Omini.Opme.Business.Abstractions.Messaging;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Domain.Services.Pdf;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Application.Commands;

public record PreviewQuotationCommand : ICommand<byte[]>
{
    public Guid Id { get; set; }

    public class PreviewQuotationHandler : ICommandHandler<PreviewQuotationCommand, byte[]>
    {
        private readonly IQuotationPdfGenerator _quotationPdfGenerator;
        private readonly IQuotationRepository _quotationRepository;
        public PreviewQuotationHandler(IQuotationPdfGenerator quotationPdfGenerator, IQuotationRepository quotationRepository)
        {
            _quotationPdfGenerator = quotationPdfGenerator;
            _quotationRepository = quotationRepository;
        }

        public async Task<Result<byte[], ValidationResult>> Handle(PreviewQuotationCommand request, CancellationToken cancellationToken)
        {
            var validationFailures = new List<ValidationFailure>();
            var quotation = await _quotationRepository.GetById(request.Id);
            if (quotation is null)
            {
                validationFailures.Add(new ValidationFailure(nameof(request.Id), "Invalid id"));
            }

            if (validationFailures.Any())
            {
                return new ValidationResult(validationFailures);
            }

            var document = _quotationPdfGenerator.GenerateBytes(quotation!);

            return document;
        }
    }
}