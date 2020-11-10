﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platypus;

namespace Platypus.Migrations
{
    [DbContext(typeof(PlatypusContext))]
    [Migration("20201022072016_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Platypus.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Platypus.Models.Floor", b =>
                {
                    b.Property<int>("FloorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bookable");

                    b.Property<int>("CurrentCapacity");

                    b.Property<string>("FloorName");

                    b.Property<int>("MaxCapacity");

                    b.Property<int?>("OfficeID");

                    b.HasKey("FloorID");

                    b.HasIndex("OfficeID");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("Platypus.Models.MiniLogin", b =>
                {
                    b.Property<int>("MiniLoginID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<int>("UserID");

                    b.Property<string>("UserName");

                    b.HasKey("MiniLoginID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Platypus.Models.Office", b =>
                {
                    b.Property<int>("OfficeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BannerMessage");

                    b.Property<int>("CompanyID");

                    b.Property<int>("CurrentCapacity");

                    b.Property<string>("OfficeName");

                    b.Property<int>("TotalCapacity");

                    b.HasKey("OfficeID");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Platypus.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookerID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("FloorID");

                    b.Property<int>("OfficeID");

                    b.HasKey("ReservationID");

                    b.HasIndex("FloorID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Platypus.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin");

                    b.Property<int>("CompanyID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("ReservationID");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Platypus.Models.Floor", b =>
                {
                    b.HasOne("Platypus.Models.Office")
                        .WithMany("floors")
                        .HasForeignKey("OfficeID");
                });

            modelBuilder.Entity("Platypus.Models.Reservation", b =>
                {
                    b.HasOne("Platypus.Models.Floor")
                        .WithMany("Reservations")
                        .HasForeignKey("FloorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Platypus.Models.User", b =>
                {
                    b.HasOne("Platypus.Models.Reservation")
                        .WithMany("Mancers")
                        .HasForeignKey("ReservationID");
                });
#pragma warning restore 612, 618
        }
    }
}
