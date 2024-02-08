using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDiplomTST.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewPropInTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tests");
        }
    }
}
