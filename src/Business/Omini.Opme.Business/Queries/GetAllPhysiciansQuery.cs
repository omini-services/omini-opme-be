using Omini.Opme.Business.Abstractions.Messaging;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Business.Queries;

public class GetAllPhysiciansQuery : IQuery<Physician>
{
    public GetAllPhysiciansQuery() { }

    public GetAllPhysiciansQuery(string queryValue, PaginationFilter paginationFilter)
    {
        QueryValue = queryValue;
        PaginationFilter = paginationFilter;
    }

    public string QueryValue { get; set; }
    public PaginationFilter PaginationFilter { get; set; }

    public class GetAllPhysiciansQueryHandler : IQueryHandler<GetAllPhysiciansQuery, Physician>
    {
        private readonly IPhysicianRepository _physicianRepository;
        public GetAllPhysiciansQueryHandler(IPhysicianRepository physicianRepository)
        {
            _physicianRepository = physicianRepository;
        }

        public async Task<PagedResult<Physician>> Handle(GetAllPhysiciansQuery request, CancellationToken cancellationToken)
        {
            var physicians = await _physicianRepository.GetAll(
                currentPage: request.PaginationFilter.CurrentPage,
                pageSize: request.PaginationFilter.PageSize,
                orderByField: request.PaginationFilter.OrderBy,
                sortDirection: request.PaginationFilter.Direction,
                queryValue: request.QueryValue,
                cancellationToken);

            return physicians;
        }
    }
}