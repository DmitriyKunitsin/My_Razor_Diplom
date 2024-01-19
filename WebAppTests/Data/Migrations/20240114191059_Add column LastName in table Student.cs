using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTests.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumnLastNameintableStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "data",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "LastName" },
                values: new object[] { new DateTime(2004, 1, 15, 2, 10, 57, 930, DateTimeKind.Local).AddTicks(8947), "Mamedov" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "data",
                table: "Students");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 1, 15, 0, 23, 22, 730, DateTimeKind.Local).AddTicks(4513));
        }
    }
}
