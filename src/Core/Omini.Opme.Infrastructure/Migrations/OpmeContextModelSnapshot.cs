﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Omini.Opme.Infrastructure.Contexts;

#nullable disable

namespace Omini.Opme.Infrastructure.Migrations
{
    [DbContext(typeof(OpmeContext))]
    partial class OpmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Omini.Opme.Domain.Admin.InternalSpecialist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InternalSpecialists", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.Admin.OpmeUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("OpmeUsers", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Hospitals", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.InsuranceCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanies", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Physician", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Cro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Physicians", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.Sales.Quotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InsuranceCompanyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PayingSourceId")
                        .HasColumnType("uuid");

                    b.Property<string>("PayingSourceType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PhysicianId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("InsuranceCompanyId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PhysicianId");

                    b.ToTable("Quotations", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.Sales.QuotationItem", b =>
                {
                    b.Property<Guid>("QuotationId")
                        .HasColumnType("uuid");

                    b.Property<int>("LineId")
                        .HasColumnType("integer");

                    b.Property<string>("AnvisaCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("AnvisaDueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("LineOrder")
                        .HasColumnType("integer");

                    b.Property<decimal>("LineTotal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("ReferenceCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("QuotationId", "LineId");

                    b.HasIndex("ItemId");

                    b.ToTable("QuotationItems", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.Warehouse.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnvisaCode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("AnvisaDueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Cst")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NcmCode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SalesName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SupplierCode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SusCode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Uom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Omini.Opme.Domain.Admin.InternalSpecialist", b =>
                {
                    b.OwnsOne("Omini.Opme.Domain.PersonName", "Name", b1 =>
                        {
                            b1.Property<Guid>("InternalSpecialistId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("MiddleName");

                            b1.HasKey("InternalSpecialistId");

                            b1.ToTable("InternalSpecialists");

                            b1.WithOwner()
                                .HasForeignKey("InternalSpecialistId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Hospital", b =>
                {
                    b.OwnsOne("Omini.Opme.Domain.CompanyName", "Name", b1 =>
                        {
                            b1.Property<Guid>("HospitalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LegalName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("LegalName");

                            b1.Property<string>("TradeName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("TradeName");

                            b1.HasKey("HospitalId");

                            b1.ToTable("Hospitals");

                            b1.WithOwner()
                                .HasForeignKey("HospitalId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.InsuranceCompany", b =>
                {
                    b.OwnsOne("Omini.Opme.Domain.CompanyName", "Name", b1 =>
                        {
                            b1.Property<Guid>("InsuranceCompanyId")
                                .HasColumnType("uuid");

                            b1.Property<string>("LegalName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("LegalName");

                            b1.Property<string>("TradeName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("TradeName");

                            b1.HasKey("InsuranceCompanyId");

                            b1.ToTable("InsuranceCompanies");

                            b1.WithOwner()
                                .HasForeignKey("InsuranceCompanyId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Patient", b =>
                {
                    b.OwnsOne("Omini.Opme.Domain.PersonName", "Name", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("MiddleName");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.BusinessPartners.Physician", b =>
                {
                    b.OwnsOne("Omini.Opme.Domain.PersonName", "Name", b1 =>
                        {
                            b1.Property<Guid>("PhysicianId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("MiddleName");

                            b1.HasKey("PhysicianId");

                            b1.ToTable("Physicians");

                            b1.WithOwner()
                                .HasForeignKey("PhysicianId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.Sales.Quotation", b =>
                {
                    b.HasOne("Omini.Opme.Domain.BusinessPartners.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Omini.Opme.Domain.BusinessPartners.InsuranceCompany", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("InsuranceCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Omini.Opme.Domain.BusinessPartners.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Omini.Opme.Domain.BusinessPartners.Physician", "Physician")
                        .WithMany()
                        .HasForeignKey("PhysicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("InsuranceCompany");

                    b.Navigation("Patient");

                    b.Navigation("Physician");
                });

            modelBuilder.Entity("Omini.Opme.Domain.Sales.QuotationItem", b =>
                {
                    b.HasOne("Omini.Opme.Domain.Warehouse.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Omini.Opme.Domain.Sales.Quotation", null)
                        .WithMany("Items")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Omini.Opme.Domain.Sales.Quotation", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
