using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class addexam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c786b0d-0e9f-4ad9-8664-7c8e37169bb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c271b69d-09ca-4dca-8d1b-0a71b1c6a83d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef4915d-53ac-4c52-94da-996e8a99ff55");

            migrationBuilder.DropColumn(
                name: "TotalMarks",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "MarkOptained",
                table: "ExamResults",
                newName: "TotalScore");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f94e20-0df3-4feb-baf0-806e928fa331", "de518910-b345-4d15-b424-508e9804cf26", "Teacher", "teacher" },
                    { "a330c183-7ddb-486b-adf3-bd942477cb82", "8225d09b-0ec3-465b-bae3-cef87d25b011", "Admin", "admin" },
                    { "f27111aa-ac94-464d-a6fb-fadcd96258c6", "4a623c0d-7e44-4d8a-818a-5cb10359879d", "User", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_ExamId",
                table: "questions",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f94e20-0df3-4feb-baf0-806e928fa331");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a330c183-7ddb-486b-adf3-bd942477cb82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f27111aa-ac94-464d-a6fb-fadcd96258c6");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "TotalScore",
                table: "ExamResults",
                newName: "MarkOptained");

            migrationBuilder.AddColumn<int>(
                name: "TotalMarks",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "ExamResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c786b0d-0e9f-4ad9-8664-7c8e37169bb6", "9c20a713-0b1f-4307-a94b-44114e4ea4be", "User", "user" },
                    { "c271b69d-09ca-4dca-8d1b-0a71b1c6a83d", "5521883c-95eb-4229-b9cc-9a0caf9e9698", "Teacher", "teacher" },
                    { "fef4915d-53ac-4c52-94da-996e8a99ff55", "8e30a8b9-9f25-4bc8-9554-d5b62536bd04", "Admin", "admin" }
                });
        }
    }
}
