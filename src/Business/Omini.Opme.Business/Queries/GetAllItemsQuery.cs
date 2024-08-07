using Omini.Opme.Business.Abstractions.Messaging;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Domain.Warehouse;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Business.Queries;

public class GetAllItemsQuery : IQuery<Item>
{
    public GetAllItemsQuery() { }

    public GetAllItemsQuery(string queryValue, PaginationFilter paginationFilter)
    {
        QueryValue = queryValue;
        PaginationFilter = paginationFilter;
    }
    public string QueryValue { get; set; }
    public PaginationFilter PaginationFilter { get; set; }


    public class GetAllItemsQueryHandler : IQueryHandler<GetAllItemsQuery, Item>
    {
        private readonly IItemRepository _itemRepository;
        public GetAllItemsQueryHandler(IItemRepository itemRepositoryy)
        {
            _itemRepository = itemRepositoryy;
        }

        public async Task<PagedResult<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAll(
                currentPage: request.PaginationFilter.CurrentPage,
                pageSize: request.PaginationFilter.PageSize,
                orderByField: request.PaginationFilter.OrderBy,
                sortDirection: request.PaginationFilter.Direction,
                queryValue: request.QueryValue,
                cancellationToken);

            return items;
        }
    }
}