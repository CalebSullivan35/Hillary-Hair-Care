﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillaryHairCare.Migrations
{
    [DbContext(typeof(HillaryHairCareDbContext))]
    partial class HillaryHairCareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.Property<int>("AppointmentsId")
                        .HasColumnType("integer");

                    b.Property<int>("ServicesId")
                        .HasColumnType("integer");

                    b.HasKey("AppointmentsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("AppointmentService");

                    b.HasData(
                        new
                        {
                            AppointmentsId = 1,
                            ServicesId = 1
                        },
                        new
                        {
                            AppointmentsId = 1,
                            ServicesId = 3
                        },
                        new
                        {
                            AppointmentsId = 2,
                            ServicesId = 2
                        },
                        new
                        {
                            AppointmentsId = 2,
                            ServicesId = 3
                        },
                        new
                        {
                            AppointmentsId = 3,
                            ServicesId = 1
                        },
                        new
                        {
                            AppointmentsId = 4,
                            ServicesId = 4
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentTime = new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 5,
                            StylistId = 2
                        },
                        new
                        {
                            Id = 2,
                            AppointmentTime = new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            StylistId = 3
                        },
                        new
                        {
                            Id = 3,
                            AppointmentTime = new DateTime(2023, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            StylistId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentTime = new DateTime(2023, 9, 15, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            StylistId = 4
                        },
                        new
                        {
                            Id = 5,
                            AppointmentTime = new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 6,
                            StylistId = 5
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kai Sa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yuumi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tahm Kench"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Janna"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Reneketon"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ashe"
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ServiceRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Basic Wash",
                            ServiceRate = 15.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "You Stinky Wash",
                            ServiceRate = 25.99m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Green Dye",
                            ServiceRate = 22.49m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Quick Cut",
                            ServiceRate = 19.99m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Total Makeover",
                            ServiceRate = 74.99m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Kid Clip",
                            ServiceRate = 7.99m
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Marissa Sullivan"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Joseph Pearson"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = false,
                            Name = "Chris Mills"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "David TankTop"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = false,
                            Name = "Deanna David"
                        });
                });

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.HasOne("HillaryHairCare.Models.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillaryHairCare.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HillaryHairCare.Models.Appointment", b =>
                {
                    b.HasOne("HillaryHairCare.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillaryHairCare.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });
#pragma warning restore 612, 618
        }
    }
}
