using MediatR;
using Omini.Opme.Be.Domain;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Domain.Transactions;
using Omini.Opme.Be.Shared.Entities;

namespace Omini.Opme.Be.Application.Commands;

public record ItemCreateCommand : IRequest<Result<Item, ValidationFailed>>
{
    public string Code { get; init; }
    public string Name { get; init; }
    public string SalesName { get; init; }
    public string Description { get; init; }
    public string Uom { get; init; }
    public string AnvisaCode { get; init; }
    public DateTime AnvisaDueDate { get; init; }
    public string SupplierCode { get; init; }
    public string Cst { get; init; }
    public string SusCode { get; init; }
    public string NcmCode { get; init; }


    public class ItemCreateCommandHandler : IRequestHandler<ItemCreateCommand, Result<Item, ValidationFailed>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;
        public ItemCreateCommandHandler(IUnitOfWork unitOfWork, IItemRepository itemRepository)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
        }

        public Task<Result<Item, ValidationFailed>> Handle(ItemCreateCommand request, CancellationToken cancellationToken)
        {
            var item = new Item(request.Name);
            //foreach (var expenseCommand in command.Expenses)
            //{
            //    expenseGroup.AddExpense(new ExpenseGroupChildren(expenseCommand.Name, expenseCommand.ExtItemCode, expenseCommand.ExtUsage));
            //}

            await _itemRepository.Create(item);
            await _unitOfWork.Commit();

            return item;
        }
    }
}