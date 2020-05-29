using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw12_Lab11_.Migrations
{
    public partial class ConfiguredDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    BirdthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: true),
                    doctorIdDoctor = table.Column<int>(nullable: true),
                    IdPatient = table.Column<int>(nullable: true),
                    patientIdPatient = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_doctorIdDoctor",
                        column: x => x.doctorIdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_patientIdPatient",
                        column: x => x.patientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    medicamentIdMedicament = table.Column<int>(nullable: true),
                    prescriptionIdPrescription = table.Column<int>(nullable: true),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions_Medicaments", x => new { x.IdPrescription, x.IdMedicament });
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medicaments_Medicaments_medicamentIdMedicament",
                        column: x => x.medicamentIdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medicaments_Prescriptions_prescriptionIdPrescription",
                        column: x => x.prescriptionIdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "L.Shwarcenberg@hospital.com", "Larry", "Shwarcenberg" },
                    { 2, "Dalton.G@hospital.com", "Garry", "Dalton" },
                    { 3, "F.Lamerke@hospital.com", "Frederic", "Lamerke" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Antigistamine", "Cetrine", "Anti-Alegetic" },
                    { 2, "D3,B2,Calcium", "Vitamine", "Supliment" },
                    { 3, "Hearbs to calm down)))", "Satotrean", "Anti_DIpresant" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirdthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 11, 5, 5, 5, 5, 0, DateTimeKind.Unspecified), "Susan", "Hearton" },
                    { 2, new DateTime(1997, 9, 8, 10, 9, 5, 0, DateTimeKind.Unspecified), "Betty", "Black" },
                    { 3, new DateTime(1983, 5, 29, 3, 30, 0, 0, DateTimeKind.Unspecified), "Jessica", "Kolt" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient", "doctorIdDoctor", "patientIdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 3, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, null },
                    { 2, new DateTime(2000, 3, 20, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null, null },
                    { 3, new DateTime(2000, 3, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose", "medicamentIdMedicament", "prescriptionIdPrescription" },
                values: new object[,]
                {
                    { 1, 1, "Two times a Day", 1, null, null },
                    { 2, 2, "Before Meal", 2, null, null },
                    { 3, 3, "After meal", 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_doctorIdDoctor",
                table: "Prescriptions",
                column: "doctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_patientIdPatient",
                table: "Prescriptions",
                column: "patientIdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_Medicaments_medicamentIdMedicament",
                table: "Prescriptions_Medicaments",
                column: "medicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_Medicaments_prescriptionIdPrescription",
                table: "Prescriptions_Medicaments",
                column: "prescriptionIdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions_Medicaments");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
