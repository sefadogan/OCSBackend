﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OCS.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace OCS.DataAccess.Migrations
{
    [DbContext(typeof(OCSDbContext))]
    partial class OCSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OCS.Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Münir",
                            IsDeleted = false,
                            LastName = "Özkul"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Adile",
                            IsDeleted = false,
                            LastName = "Naşit"
                        });
                });

            modelBuilder.Entity("OCS.Entities.Concrete.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Maltepe"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Kadıköy"
                        });
                });

            modelBuilder.Entity("OCS.Entities.Concrete.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("OrderTrackingNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ReleasedForDistribution")
                        .HasColumnType("bit");

                    b.Property<string>("ShipmentTrackingNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("OrderTrackingNo")
                        .IsUnique();

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OrderTrackingNo-1",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ShipmentTrackingNo-1",
                            Status = 2
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OrderTrackingNo-2",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ShipmentTrackingNo-2",
                            Status = 3
                        });
                });

            modelBuilder.Entity("OCS.Entities.Concrete.Order", b =>
                {
                    b.HasOne("OCS.Entities.Concrete.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OCS.Entities.Concrete.District", "District")
                        .WithMany("Orders")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("District");
                });

            modelBuilder.Entity("OCS.Entities.Concrete.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OCS.Entities.Concrete.District", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
