﻿// <auto-generated />
using System;
using Drivers.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Drivers.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(DriversDbContext))]
    partial class DriversDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Drivers.Models.Entities.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Drivers.Models.Entities.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly>("DriverSince")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("101ca01f-8dc7-4663-98d2-168dcff327a1"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 0, 0, 0, 0)),
                            DriverSince = new DateOnly(2024, 10, 1),
                            Name = "Eneas Martins Dias"
                        },
                        new
                        {
                            Id = new Guid("8dbaed53-7981-4c2a-b398-cd9e102f1867"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 0, 0, 0, 0)),
                            DriverSince = new DateOnly(2024, 9, 1),
                            Name = "Maria Aparecida Martins Dias"
                        },
                        new
                        {
                            Id = new Guid("21299a2d-90a2-40ce-923e-3ec90a714201"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 0, 0, 0, 0)),
                            DriverSince = new DateOnly(2024, 9, 1),
                            Name = "Erica Martins Dias"
                        },
                        new
                        {
                            Id = new Guid("4b4e6600-7a5a-488c-9ab1-beb1679a3e2f"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8056), new TimeSpan(0, 0, 0, 0, 0)),
                            DriverSince = new DateOnly(2024, 11, 1),
                            Name = "Cristiano Martins Dias"
                        },
                        new
                        {
                            Id = new Guid("cd85c2d2-eaed-499b-97ff-1df08984275d"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8060), new TimeSpan(0, 0, 0, 0, 0)),
                            DriverSince = new DateOnly(2024, 8, 1),
                            Name = "Adriana da Silva de Sena"
                        });
                });

            modelBuilder.Entity("Drivers.Models.Entities.Achievement", b =>
                {
                    b.HasOne("Drivers.Models.Entities.Driver", "Driver")
                        .WithMany("Achievements")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Achievements_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Drivers.Models.Entities.Driver", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}