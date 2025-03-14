using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Omini.Opme.Domain.Admin;
using Omini.Opme.Domain.Authentication;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Domain.Sales;
using Omini.Opme.Domain.Warehouse;
using Omini.Opme.Infrastructure.Extensions;

namespace Omini.Opme.Infrastructure.Contexts;

public sealed class OpmeContext : DbContext
{
    public OpmeContext(DbContextOptions<OpmeContext> options)
        : base(options)
    {
        ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
        ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
        
    }
    
    public DbSet<OpmeUser> OpmeUsers { get; set; }
    public DbSet<Company> Companies { get; set; }
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
        builder.CreateSequences();

        builder.ApplyConfigurationsFromAssembly(typeof(OpmeContext).Assembly);

        builder.EnableSoftDeleteQuery();

        builder.ApplyDefaultRules();
        builder.Seed();

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}