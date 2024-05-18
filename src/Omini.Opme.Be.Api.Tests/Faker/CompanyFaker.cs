using Bogus;
using Bogus.DataSets;
using Omini.Opme.Be.Domain;

public static class CompanyFaker
{
    public static CompanyName CompanyName()
    {
        var company = new Company();
        var companyName = company.CompanyName();
        var companySuffix = company.CompanySuffix();

        return new Faker<CompanyName>()
            .CustomInstantiator(f => new CompanyName($"{companySuffix} {companyName}", companyName));
    }
}