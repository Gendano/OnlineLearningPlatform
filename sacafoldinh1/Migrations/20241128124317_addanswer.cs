using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class addanswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "343cfa60-9578-42a0-a7da-8785c2d30f51", "fb772f2f-19d1-4917-84aa-8d9d6b4a98a7", "Teacher", "teacher" },
                    { "3a017a46-e900-4565-bb10-0626b62df84e", "aef02aa4-2839-40fc-a7a0-97c31bbb1678", "Admin", "admin" },
                    { "dbe0d42b-17fb-4f89-b116-1f02af6f5058", "890dc671-7701-445d-896c-9959513c2d65", "User", "user" }
                });
             
            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343cfa60-9578-42a0-a7da-8785c2d30f51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a017a46-e900-4565-bb10-0626b62df84e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe0d42b-17fb-4f89-b116-1f02af6f5058");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f94e20-0df3-4feb-baf0-806e928fa331", "de518910-b345-4d15-b424-508e9804cf26", "Teacher", "teacher" },
                    { "a330c183-7ddb-486b-adf3-bd942477cb82", "8225d09b-0ec3-465b-bae3-cef87d25b011", "Admin", "admin" },
                    { "f27111aa-ac94-464d-a6fb-fadcd96258c6", "4a623c0d-7e44-4d8a-818a-5cb10359879d", "User", "user" }
                });
        }
    }
}
