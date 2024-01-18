using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTests.Data.Migrations
{
    /// <inheritdoc />
    public partial class Userchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ApplicationID",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "AspNetUsers");
        }
    }
}
