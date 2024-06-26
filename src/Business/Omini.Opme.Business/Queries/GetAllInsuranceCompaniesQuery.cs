using Omini.Opme.Application.Abstractions.Messaging;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Repositories;
using Omini.Opme.Shared.Entities;

namespace Omini.Opme.Business.Queries;

public class GetAllInsuranceCompaniesQuery : IQuery<InsuranceCompany>
{
    public GetAllInsuranceCompaniesQuery() { }

    public GetAllInsuranceCompaniesQuery(QueryFilter queryFilter, PaginationFilter paginationFilter)
    {
        QueryFilter = queryFilter;
        PaginationFilter = paginationFilter;
    }

    public PaginationFilter PaginationFilter { get; set; }

    public QueryFilter QueryFilter { get; set; }
    
    public class GetAllInsuranceCompaniesQueryHandler : IQueryHandler<GetAllInsuranceCompaniesQuery, InsuranceCompany>
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        public GetAllInsuranceCompaniesQueryHandler(IInsuranceCompanyRepository insuranceCompanyRepository)
        {
            _insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task<PagedResult<InsuranceCompany>> Handle(GetAllInsuranceCompaniesQuery request, CancellationToken cancellationToken)
        {
            var insuranceCompanies = await _insuranceCompanyRepository.GetAll(
                currentPage: request.PaginationFilter.CurrentPage,
                pageSize: request.PaginationFilter.PageSize,
                orderByField: request.PaginationFilter.OrderBy,
                sortDirection: request.PaginationFilter.Direction,
                queryField: request.QueryFilter.QueryField,
                queryValue: request.QueryFilter.QueryValue,
                cancellationToken);

            return insuranceCompanies;
        }
    }
}