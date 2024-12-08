using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class moduleDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "083794f6-23a4-4157-8554-abcecb73ac0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36977141-cb02-4027-80ce-f4188bc12920");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7407aa3d-0215-4e64-9e25-e9545ee52f62");

            migrationBuilder.RenameColumn(
                name: "TiTle",
                table: "Lessons",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Modules",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Lessons",
                newName: "TiTle");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "083794f6-23a4-4157-8554-abcecb73ac0e", "2f919863-4604-4e7d-914c-684bcc338968", "Teacher", "teacher" },
                    { "36977141-cb02-4027-80ce-f4188bc12920", "b3c1678b-1cfa-4088-8ceb-0143131796fc", "User", "user" },
                    { "7407aa3d-0215-4e64-9e25-e9545ee52f62", "8f481abf-d301-4fad-a669-0c362eeb31b1", "Admin", "admin" }
                });
        }
    }
}
