﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketManager.Infrastructure.Persistance;

#nullable disable

namespace TicketManager.Infrastructure.Migrations
{
    [DbContext(typeof(TicketManagerDbContext))]
    [Migration("20240707125111_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketManager.Models.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FactoryLocationId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("FactoryLocationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TicketManager.Models.Models.FactoryLocation", b =>
                {
                    b.Property<int>("FactoryLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FactoryLocationId"));

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Factory")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("FactoryLocationId");

                    b.ToTable("FactoryLocations");
                });

            modelBuilder.Entity("TicketManager.Models.Models.LabLocation", b =>
                {
                    b.Property<int>("LabLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabLocationId"));

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Factory")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("LabLocationId");

                    b.ToTable("LabLocations");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("ProductDisplacementId")
                        .HasColumnType("int");

                    b.Property<string>("ProductFamilly")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductDisplacementId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TicketManager.Models.Models.ProductDisplacement", b =>
                {
                    b.Property<int>("ProductDisplacementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDisplacementId"));

                    b.Property<int>("Displacement")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductDisplacementId");

                    b.ToTable("ProductDisplacements");
                });

            modelBuilder.Entity("TicketManager.Models.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTypeId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductTypeDesc")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("TicketManager.Models.Models.ReportStructure", b =>
                {
                    b.Property<int>("ReportStructureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportStructureId"));

                    b.Property<string>("FolderDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.HasKey("ReportStructureId");

                    b.ToTable("ReportStructures");
                });

            modelBuilder.Entity("TicketManager.Models.Models.ReportType", b =>
                {
                    b.Property<int>("ReportTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportTypeId"));

                    b.Property<string>("ReportDescription")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ReportShortType")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("ReportTypeId");

                    b.ToTable("ReportTypes");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<string>("TestDescription")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TestUnits")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ImplementedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("LabLocationId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RequestorEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LabLocationId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketManager.Models.Models.TicketStatus", b =>
                {
                    b.Property<int>("TicketStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketStatusId"));

                    b.Property<string>("StatusDescription")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("TicketStatusId");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("TicketManager.Models.Models.TicketTest", b =>
                {
                    b.Property<int>("TicketTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketTestId"));

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<double>("TestParameter")
                        .HasColumnType("float");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("TicketTestId");

                    b.HasIndex("TestId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketTests");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Department", b =>
                {
                    b.HasOne("TicketManager.Models.Models.FactoryLocation", "Factorylocation")
                        .WithMany()
                        .HasForeignKey("FactoryLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factorylocation");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Product", b =>
                {
                    b.HasOne("TicketManager.Models.Models.ProductDisplacement", "ProductDisplacement")
                        .WithMany()
                        .HasForeignKey("ProductDisplacementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Models.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDisplacement");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Ticket", b =>
                {
                    b.HasOne("TicketManager.Models.Models.Department", "RequestorDepartment")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Models.Models.LabLocation", "LabLocation")
                        .WithMany()
                        .HasForeignKey("LabLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Models.Models.TicketStatus", "TicketStatus")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LabLocation");

                    b.Navigation("Product");

                    b.Navigation("RequestorDepartment");

                    b.Navigation("TicketStatus");
                });

            modelBuilder.Entity("TicketManager.Models.Models.TicketTest", b =>
                {
                    b.HasOne("TicketManager.Models.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketManager.Models.Models.Ticket", null)
                        .WithMany("TicketTests")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TicketManager.Models.Models.Ticket", b =>
                {
                    b.Navigation("TicketTests");
                });
#pragma warning restore 612, 618
        }
    }
}
