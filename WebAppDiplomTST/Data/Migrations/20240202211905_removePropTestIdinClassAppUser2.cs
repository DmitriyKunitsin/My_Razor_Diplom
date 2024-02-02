using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDiplomTST.Data.Migrations
{
    /// <inheritdoc />
    public partial class removePropTestIdinClassAppUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Tests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
