using Microsoft.EntityFrameworkCore;
using Omini.Opme.Domain.Admin;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Sales;
using Omini.Opme.Domain.Warehouse;
using Omini.Opme.Infrastructure.Extensions;

namespace Omini.Opme.Infrastructure.Contexts;

internal sealed class OpmeContext : DbContext
{
    public OpmeContext(DbContextOptions<OpmeContext> options)
        : base(options)
    {
    }
    public DbSet<OpmeUser> OpmeUsers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Physician> Physicians { get; set; }
    public DbSet<InternalSpecialist> InternalSpecialists { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<QuotationItem> QuotationItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Ignore<Notification>();
        builder.ApplyConfigurationsFromAssembly(typeof(OpmeContext).Assembly);

        builder.EnableSoftDelete();

        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .HaveMaxLength(100);

        base.ConfigureConventions(configurationBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
// private void UpdateCompanyId(EntityEntry entry)
// {
//     if (ShouldUpdateCompanyId(entry))
//     {
//         if (entry.State == EntityState.Added)
//             entry.Property("CompanyId").CurrentValue = _userService.GetCompanyId();
//         else if (entry.State == EntityState.Modified)
//             entry.Property("CompanyId").IsModified = false;
//     }
// }

// private static bool ShouldUpdateCompanyId(EntityEntry entry)
// {
//     return entry.Entity.GetType().GetProperty("CompanyId") != null;
// }
