using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Omini.Opme.Domain.Admin;
using Omini.Opme.Domain.Authentication;
using Omini.Opme.Domain.Common;

namespace Omini.Opme.Infrastructure.Extensions;

internal static class ModelBuilderExtensions
{
    public const string ItemCodeSequence = "itemcode_sequence";
    public const string HospitalCodeSequence = "hospitalcode_sequence";
    public const string PatientCodeSequence = "patientcode_sequence";
    public const string PhysicianCodeSequence = "physiciancode_sequence";
    public const string InsuranceCompanyCodeSequence = "insurancecompanycode_sequence";
    public const string InternalSpecialistCodeSequence = "internalspecialistcode_sequence";

    public static void EnableSoftDeleteQuery(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes()
            .Where(e => typeof(ISoftDeletable).IsAssignableFrom(e.ClrType)))
        {
            var param = Expression.Parameter(entityType.ClrType, "entity");
            var prop = Expression.PropertyOrField(param, nameof(ISoftDeletable.IsDeleted));
            var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);

            entityType.SetQueryFilter(entityNotDeleted);
        }
    }

    public static void ApplyDefaultRules(this ModelBuilder builder)
    {
        var notIncludedEntities = new string[] { "Item" };
        var notIncludedFields = new string[] { "Code" };

        var stringProperties = builder.Model.GetEntityTypes()
           .Where(t => !notIncludedEntities.Contains(t.ClrType.Name))
           .SelectMany(t => t.GetProperties())
           .Where(p => p.ClrType == typeof(string) && !notIncludedFields.All(n => p.Name.EndsWith(n)));

        foreach (var property in stringProperties.Where(p => p.Name != "Comments"))
            property.SetMaxLength(100);
    }

    public static void CreateSequences(this ModelBuilder builder)
    {
        builder.HasSequence<long>(ItemCodeSequence);
        builder.HasSequence<long>(HospitalCodeSequence);
        builder.HasSequence<long>(PatientCodeSequence);
        builder.HasSequence<long>(PhysicianCodeSequence);
        builder.HasSequence<long>(InsuranceCompanyCodeSequence);
        builder.HasSequence<long>(InternalSpecialistCodeSequence);
    }

    public static void Seed(this ModelBuilder builder)
    {
        var rootUserGuid = new Guid("c8c5ce24-820f-41ba-8560-d7a282d80d29");

        builder.Entity<OpmeUser>().HasData(
            new OpmeUser
            {
                Id = rootUserGuid,
                Email = "test@invalid.com",
                CreatedBy = rootUserGuid,
                CreatedOn = DateTime.UtcNow,
            },
            new OpmeUser
            {
                Id = new Guid("e6211f68-cfcd-40e9-a31a-bd0dcf4b4052"),
                Email = "dacceto@gmail.com",
                CreatedBy = rootUserGuid,
                CreatedOn = DateTime.UtcNow,
            },
            new OpmeUser
            {
                Id = new Guid("77e48701-6371-4e3e-8d92-9db4a2bc1e5f"),
                Email = "guilherme_or@outlook.com",
                CreatedBy = rootUserGuid,
                CreatedOn = DateTime.UtcNow,
            }
        );

        builder.Entity<InternalSpecialist>().HasData(
            new
            {
                Code = "1",
                Email = "comercial@fratermedical.com.br",
                Telefone = "(11) 3829-9400",
                CreatedBy = rootUserGuid,
                CreatedOn = DateTime.UtcNow,
            }
        );

        builder.Entity<InternalSpecialist>().OwnsOne(p => p.Name).HasData(
            new
            {
                InternalSpecialistCode = "1",
                FirstName = "Nathália",
                LastName = "Camelo",
            }
        );
    }
}