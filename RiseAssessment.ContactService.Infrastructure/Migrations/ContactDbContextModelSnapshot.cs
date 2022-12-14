// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RiseAssessment.ContactService.Infrastructure.Context;

#nullable disable

namespace RiseAssessment.ContactService.Infrastructure.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    partial class ContactDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RiseAssessment.ContactService.Domain.Models.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAtUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedAtUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("RiseAssessment.ContactService.Domain.Models.Entities.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAtUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InformationContent")
                        .HasColumnType("text");

                    b.Property<int>("InformationType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAtUTC")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("RiseAssessment.ContactService.Domain.Models.Entities.ContactInformation", b =>
                {
                    b.HasOne("RiseAssessment.ContactService.Domain.Models.Entities.Contact", "Contact")
                        .WithMany("ContactInfo")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("RiseAssessment.ContactService.Domain.Models.Entities.Contact", b =>
                {
                    b.Navigation("ContactInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
