using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omini.Opme.Domain.BusinessPartners;
using Omini.Opme.Infrastructure.Extensions;

namespace Omini.Opme.Infrastructure.Mappings;

internal sealed class PhysicianMapping : MasterEntityMapping<Physician>
{
    public override void Configure(EntityTypeBuilder<Physician> builder)
    {
        base.Configure(builder);
        
        builder.HasKey(x => x.Code);

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .HasDefaultValueSql($"nextval ('{ModelBuilderExtensions.PhysicianCodeSequence}')")
            .IsRequired();

        builder.OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .IsRequired();

        builder.OwnsOne(x => x.Name)
            .Property(x => x.MiddleName)
            .HasColumnName("MiddleName");

        builder.OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .HasColumnName("LastName")
            .IsRequired();

        builder.ToTable("Physicians");
    }
}
