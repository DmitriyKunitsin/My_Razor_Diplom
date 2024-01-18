using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTests.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovecolumninStudentPriceandDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "data",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "data",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "data",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Role" },
                values: new object[] { new DateTime(2004, 1, 18, 12, 20, 35, 909, DateTimeKind.Local).AddTicks(2732), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "data",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "data",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "data",
                table: "Students",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Deleted", "Price" },
                values: new object[] { new DateTime(2004, 1, 15, 2, 10, 57, 930, DateTimeKind.Local).AddTicks(8947), false, 999.99m });
        }
    }
}
