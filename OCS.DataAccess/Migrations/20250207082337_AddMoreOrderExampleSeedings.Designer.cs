﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OCS.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace OCS.DataAccess.Migrations
{
    [DbContext(typeof(OCSDbContext))]
    [Migration("20250207082337_AddMoreOrderExampleSeedings")]
    partial class AddMoreOrderExampleSeedings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedDate = new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1001",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2001",
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1002",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2002",
                            Status = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDate = new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1003",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2003",
                            Status = 2
                        },
                        new
                        {
                            Id = 4L,
                            CreatedDate = new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1004",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2004",
                            Status = 3
                        },
                        new
                        {
                            Id = 5L,
                            CreatedDate = new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1005",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2005",
                            Status = 4
                        },
                        new
                        {
                            Id = 6L,
                            CreatedDate = new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1006",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2006",
                            Status = 0
                        },
                        new
                        {
                            Id = 7L,
                            CreatedDate = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1007",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2007",
                            Status = 1
                        },
                        new
                        {
                            Id = 8L,
                            CreatedDate = new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1008",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2008",
                            Status = 2
                        },
                        new
                        {
                            Id = 9L,
                            CreatedDate = new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1009",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2009",
                            Status = 3
                        },
                        new
                        {
                            Id = 10L,
                            CreatedDate = new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1010",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2010",
                            Status = 4
                        },
                        new
                        {
                            Id = 11L,
                            CreatedDate = new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1011",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2011",
                            Status = 0
                        },
                        new
                        {
                            Id = 12L,
                            CreatedDate = new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1012",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2012",
                            Status = 1
                        },
                        new
                        {
                            Id = 13L,
                            CreatedDate = new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1013",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2013",
                            Status = 2
                        },
                        new
                        {
                            Id = 14L,
                            CreatedDate = new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1014",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2014",
                            Status = 3
                        },
                        new
                        {
                            Id = 15L,
                            CreatedDate = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1015",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2015",
                            Status = 4
                        },
                        new
                        {
                            Id = 16L,
                            CreatedDate = new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1016",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2016",
                            Status = 0
                        },
                        new
                        {
                            Id = 17L,
                            CreatedDate = new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1017",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2017",
                            Status = 1
                        },
                        new
                        {
                            Id = 18L,
                            CreatedDate = new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1018",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2018",
                            Status = 2
                        },
                        new
                        {
                            Id = 19L,
                            CreatedDate = new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            DistrictId = 1,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1019",
                            ReleasedForDistribution = true,
                            ShipmentTrackingNo = "ST-2019",
                            Status = 3
                        },
                        new
                        {
                            Id = 20L,
                            CreatedDate = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            DistrictId = 2,
                            IsDeleted = false,
                            OrderTrackingNo = "OT-1020",
                            ReleasedForDistribution = false,
                            ShipmentTrackingNo = "ST-2020",
                            Status = 4
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
