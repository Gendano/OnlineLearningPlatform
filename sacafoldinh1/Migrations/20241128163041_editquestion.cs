using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class editquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "questions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dd35f2e-175a-42ba-b3da-6dd295414fae", "0d3a8514-95ef-4b4b-8334-55ac29f6b0cf", "Admin", "admin" },
                    { "57e14d6c-11b5-46d3-a44c-8dbb584846ac", "1f21c0ba-5b05-4bcb-bd82-fd3faa7e5003", "User", "user" },
                    { "991983f2-06b7-44a0-ac6e-dfbdc93b2532", "ccb81313-d45e-4dfa-aced-1a81174e6700", "Teacher", "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dd35f2e-175a-42ba-b3da-6dd295414fae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e14d6c-11b5-46d3-a44c-8dbb584846ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991983f2-06b7-44a0-ac6e-dfbdc93b2532");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswer",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "343cfa60-9578-42a0-a7da-8785c2d30f51", "fb772f2f-19d1-4917-84aa-8d9d6b4a98a7", "Teacher", "teacher" },
                    { "3a017a46-e900-4565-bb10-0626b62df84e", "aef02aa4-2839-40fc-a7a0-97c31bbb1678", "Admin", "admin" },
                    { "dbe0d42b-17fb-4f89-b116-1f02af6f5058", "890dc671-7701-445d-896c-9959513c2d65", "User", "user" }
                });
        }
    }
}
