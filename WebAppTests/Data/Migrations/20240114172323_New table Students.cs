using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTests.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewtableStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "data",
                table: "Students",
                columns: new[] { "Id", "BirthDate", "Deleted", "Name", "Price" },
                values: new object[] { 1, new DateTime(2004, 1, 15, 0, 23, 22, 730, DateTimeKind.Local).AddTicks(4513), false, "Goga", 999.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students",
                schema: "data");
        }
    }
}
