﻿// <auto-generated />
using System;
using AldagiTPL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AldagiTPL.Migrations
{
    [DbContext(typeof(AldagiTPLDbContext))]
    [Migration("20221205110755_changes again")]
    partial class changesagain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AldagiTPL.Models.Clients.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AldagiTPL.Models.Marks.VehicleMarks", b =>
                {
                    b.Property<Guid>("VehicleMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleMarkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleMarkId");

                    b.ToTable("VehicleMarks");
                });

            modelBuilder.Entity("AldagiTPL.Models.Models.VehicleModels", b =>
                {
                    b.Property<Guid>("VehicleModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehicleMarkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleModelId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("AldagiTPL.Models.TPLConditions.TPLLimit", b =>
                {
                    b.Property<int>("LimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LimitId"), 1L, 1);

                    b.Property<int>("ClientIntegration")
                        .HasColumnType("int");

                    b.Property<decimal>("LimitAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Premium")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LimitId");

                    b.ToTable("TPLConditions");
                });

            modelBuilder.Entity("AldagiTPL.Models.TPLConditions.TPLStatuses", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("TPLStatusTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("TPLStatuses");
                });

            modelBuilder.Entity("AldagiTPL.Models.TPLRequest.TPLRequest", b =>
                {
                    b.Property<int>("TPLRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TPLRequestId"), 1L, 1);

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LimitId")
                        .HasColumnType("int");

                    b.Property<Guid>("MarkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VehicleYear")
                        .HasColumnType("int");

                    b.HasKey("TPLRequestId");

                    b.HasIndex("ClientId");

                    b.HasIndex("LimitId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("TPLRequests");
                });

            modelBuilder.Entity("AldagiTPL.Models.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VehicleMarkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehicleModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VehicleYear")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("VehicleMarkId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("AldagiTPL.Models.TPLRequest.TPLRequest", b =>
                {
                    b.HasOne("AldagiTPL.Models.Clients.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AldagiTPL.Models.TPLConditions.TPLLimit", "Limit")
                        .WithMany()
                        .HasForeignKey("LimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AldagiTPL.Models.TPLConditions.TPLStatuses", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AldagiTPL.Models.Vehicles.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Limit");

                    b.Navigation("Status");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AldagiTPL.Models.Vehicles.Vehicle", b =>
                {
                    b.HasOne("AldagiTPL.Models.Marks.VehicleMarks", "VehicleMark")
                        .WithMany()
                        .HasForeignKey("VehicleMarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AldagiTPL.Models.Models.VehicleModels", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMark");

                    b.Navigation("VehicleModel");
                });
#pragma warning restore 612, 618
        }
    }
}
