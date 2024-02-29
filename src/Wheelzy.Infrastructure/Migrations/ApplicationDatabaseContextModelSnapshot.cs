﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wheelzy.Infrastructure;

#nullable disable

namespace Wheelzy.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    partial class ApplicationDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wheelzy.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ford"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Chrevrolet"
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buyers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 800m,
                            Name = "John"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 300m,
                            Name = "George"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 500m,
                            Name = "Sam"
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("SubmodelId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SubmodelId");

                    b.HasIndex("MakeId", "ModelId", "SubmodelId")
                        .IsUnique();

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MakeId = 1,
                            ModelId = 1,
                            SubmodelId = 1,
                            Year = 2018,
                            ZipCode = 30033
                        },
                        new
                        {
                            Id = 2,
                            MakeId = 1,
                            ModelId = 2,
                            SubmodelId = 2,
                            Year = 2018,
                            ZipCode = 20110
                        },
                        new
                        {
                            Id = 3,
                            MakeId = 2,
                            ModelId = 1,
                            SubmodelId = 1,
                            Year = 2018,
                            ZipCode = 30315
                        },
                        new
                        {
                            Id = 4,
                            MakeId = 2,
                            ModelId = 2,
                            SubmodelId = 2,
                            Year = 2018,
                            ZipCode = 22003
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jack"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Peter"
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Description = "EcoSport"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Description = "Focus"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            Description = "Cruze"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Description = "Spark"
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PickedUpDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StatusId")
                        .IsUnique();

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuyerId = 1,
                            CarId = 1,
                            CreatedDate = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            BuyerId = 2,
                            CarId = 2,
                            CreatedDate = new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            PickedUpDate = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 4
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Acceptance"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Accepted"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Picked Up"
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Submodel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Submodels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Base",
                            ModelId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "S",
                            ModelId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Base",
                            ModelId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Eco",
                            ModelId = 2
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StatusId");

                    b.ToTable("Trackings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            StatusId = 1,
                            Timestamp = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            StatusId = 1,
                            Timestamp = new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            StatusId = 2,
                            Timestamp = new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            StatusId = 3,
                            Timestamp = new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Car", b =>
                {
                    b.HasOne("Wheelzy.Domain.Entities.Brand", "Make")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Car", "MakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Model", "Model")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Car", "ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Submodel", "Submodel")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Car", "SubmodelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Make");

                    b.Navigation("Model");

                    b.Navigation("Submodel");
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Model", b =>
                {
                    b.HasOne("Wheelzy.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Order", b =>
                {
                    b.HasOne("Wheelzy.Domain.Entities.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Customer", "Customer")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Order", "CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Status", "Status")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Order", "StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Submodel", b =>
                {
                    b.HasOne("Wheelzy.Domain.Entities.Model", "Model")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Submodel", "ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Wheelzy.Domain.Entities.Tracking", b =>
                {
                    b.HasOne("Wheelzy.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wheelzy.Domain.Entities.Status", "Status")
                        .WithOne()
                        .HasForeignKey("Wheelzy.Domain.Entities.Tracking", "StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
