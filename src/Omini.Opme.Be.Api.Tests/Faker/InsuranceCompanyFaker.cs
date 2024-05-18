using Bogus;
using Bogus.Extensions.Brazil;
using Omini.Opme.Be.Api.Dtos;

namespace Omini.Opme.Be.Api.Tests;

public static class InsuranceCompanyFaker
{
    public static InsuranceCompanyCreateDto GetFakeInsuranceCompanyCreateDto()
    {
        var companyName = CompanyFaker.CompanyName();

        return new Faker<InsuranceCompanyCreateDto>()
            .RuleFor(o => o.LegalName, f => companyName.LegalName)
            .RuleFor(o => o.TradeName, f => companyName.TradeName)
            .RuleFor(o => o.Cnpj, f => f.Company.Cnpj())
            .RuleFor(o => o.Comments, f => f.Company.Bs());
    }

    public static InsuranceCompanyUpdateDto GetFakeInsuranceCompanyUpdateDto(Guid id)
    {
        var companyName = CompanyFaker.CompanyName();

        var faker = new Faker<InsuranceCompanyUpdateDto>()
            .RuleFor(o => o.LegalName, f => companyName.LegalName)
            .RuleFor(o => o.TradeName, f => companyName.TradeName)
            .RuleFor(o => o.Cnpj, f => f.Company.Cnpj())
            .RuleFor(o => o.Comments, f => f.Company.Bs()).Generate();

        faker.Id = id;

        return faker;
    }
}