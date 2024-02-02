using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDiplomTST.Data.Migrations
{
    /// <inheritdoc />
    public partial class MaybeNorm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestId",
                table: "Question",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CourseId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
