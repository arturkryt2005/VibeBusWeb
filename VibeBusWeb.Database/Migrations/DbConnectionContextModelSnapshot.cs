﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VibeBusWeb.Database.Data;

#nullable disable

namespace VibeBusWeb.Database.Migrations
{
    [DbContext(typeof(DbConnectionContext))]
    partial class DbConnectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VibeBusWeb.Application.Data.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DeparturePointId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DestinationPointId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DestinationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeparturePointId");

                    b.HasIndex("DestinationPointId");

                    b.HasIndex("DriverId");

                    b.HasIndex("UserId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RouteId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Driver", b =>
                {
                    b.HasOne("VibeBusWeb.Application.Data.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Route", b =>
                {
                    b.HasOne("VibeBusWeb.Application.Data.City", "DeparturePoint")
                        .WithMany()
                        .HasForeignKey("DeparturePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeBusWeb.Application.Data.City", "DestinationPoint")
                        .WithMany()
                        .HasForeignKey("DestinationPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeBusWeb.Application.Data.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("VibeBusWeb.Application.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeparturePoint");

                    b.Navigation("DestinationPoint");

                    b.Navigation("Driver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VibeBusWeb.Application.Data.Trip", b =>
                {
                    b.HasOne("VibeBusWeb.Application.Data.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.HasOne("VibeBusWeb.Application.Data.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.HasOne("VibeBusWeb.Application.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Bus");

                    b.Navigation("Route");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
