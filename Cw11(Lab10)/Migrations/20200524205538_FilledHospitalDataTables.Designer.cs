﻿// <auto-generated />
using System;
using Cw11_Lab10_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw11_Lab10_.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20200524205538_FilledHospitalDataTables")]
    partial class FilledHospitalDataTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw11_Lab10_.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "L.Shwarcenberg@hospital.com",
                            FirstName = "Larry",
                            LastName = "Shwarcenberg"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "Dalton.G@hospital.com",
                            FirstName = "Garry",
                            LastName = "Dalton"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "F.Lamerke@hospital.com",
                            FirstName = "Frederic",
                            LastName = "Lamerke"
                        });
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Antigistamine",
                            Name = "Cetrine",
                            Type = "Anti-Alegetic"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "D3,B2,Calcium",
                            Name = "Vitamine",
                            Type = "Supliment"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Hearbs to calm down)))",
                            Name = "Satotrean",
                            Type = "Anti_DIpresant"
                        });
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirdthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirdthDate = new DateTime(1993, 11, 5, 5, 5, 5, 0, DateTimeKind.Unspecified),
                            FirstName = "Susan",
                            LastName = "Hearton"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirdthDate = new DateTime(1997, 9, 8, 10, 9, 5, 0, DateTimeKind.Unspecified),
                            FirstName = "Betty",
                            LastName = "Black"
                        },
                        new
                        {
                            IdPatient = 3,
                            BirdthDate = new DateTime(1983, 5, 29, 3, 30, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jessica",
                            LastName = "Kolt"
                        });
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int?>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2000, 3, 30, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2000, 3, 20, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2000, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2000, 3, 10, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2000, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 3
                        });
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Prescription_Medicament", b =>
                {
                    b.Property<int?>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int?>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament");

                    b.HasIndex("IdMedicament");

                    b.ToTable("Prescriptions_Medicaments");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 1,
                            Details = "Two times a Day",
                            Dose = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            IdMedicament = 2,
                            Details = "Before Meal",
                            Dose = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            IdMedicament = 3,
                            Details = "After meal",
                            Dose = 3
                        });
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Prescription", b =>
                {
                    b.HasOne("Cw11_Lab10_.Models.Doctor", "doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor");

                    b.HasOne("Cw11_Lab10_.Models.Patient", "patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient");
                });

            modelBuilder.Entity("Cw11_Lab10_.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("Cw11_Lab10_.Models.Medicament", "medicament")
                        .WithMany("PrescriptionsMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cw11_Lab10_.Models.Prescription", "prescription")
                        .WithMany("PrescriptionsMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
