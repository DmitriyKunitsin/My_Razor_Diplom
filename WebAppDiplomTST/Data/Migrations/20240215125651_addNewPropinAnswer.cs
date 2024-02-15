using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDiplomTST.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewPropinAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lvlQuestion",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lvlQuestion",
                table: "Answers");
        }
    }
}
