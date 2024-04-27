using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Domain.Services;
using Omini.Opme.Be.Domain.Transactions;
using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Application.Commands;

public record DeleteItemCommand : IRequest<Result<Item>>
{
    public Guid Id { get; init; }

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Result<Item>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;
        private readonly IAuditableService _auditableService;
        public DeleteItemCommandHandler(IUnitOfWork unitOfWork,
                                        IItemRepository itemRepository,
                                        IAuditableService auditableService)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
            _auditableService = auditableService;
        }

        public async Task<Result<Item>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetById(request.Id);
            if (item is null)
            {
                throw new ValidationException("Item not found", new List<ValidationFailure>() { new ValidationFailure("id", "invalid id") });
            }

            _auditableService.SoftDelete(item);

            _itemRepository.Update(item);
            await _unitOfWork.Commit();

            return item;
        }
    }
}