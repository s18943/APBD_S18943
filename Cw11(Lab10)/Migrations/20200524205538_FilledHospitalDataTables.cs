using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11_Lab10_.Migrations
{
    public partial class FilledHospitalDataTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2000, 3, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2000, 3, 20, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2000, 3, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 });

            migrationBuilder.InsertData(
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 1, 1, "Two times a Day", 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 2, 2, "Before Meal", 2 });

            migrationBuilder.InsertData(
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 3, 3, "After meal", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
