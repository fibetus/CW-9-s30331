using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_CW9.Migrations
{
    /// <inheritdoc />
    public partial class ChangemodelsDatetypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DueDate",
                table: "Prescription",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Prescription",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthdate",
                table: "Patient",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateOnly(1980, 1, 1));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateOnly(2025, 5, 27), new DateOnly(2025, 7, 15) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
