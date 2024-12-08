using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class editmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134b3729-fa9e-429c-9aea-aaea2f61828f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27e7d4da-b420-4b4b-85c4-78df6fe79410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78ed240b-5693-4fc3-b8a2-8a6368f13859");

            migrationBuilder.RenameColumn(
                name: "Tiltle",
                table: "Modules",
                newName: "Title");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Title",
                table: "Modules",
                newName: "Tiltle");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134b3729-fa9e-429c-9aea-aaea2f61828f", "6d0f85c4-4633-4e0b-8674-0366a5dc73f5", "User", "user" },
                    { "27e7d4da-b420-4b4b-85c4-78df6fe79410", "3852a00b-5dc4-42bc-8192-fa084640b382", "Teacher", "teacher" },
                    { "78ed240b-5693-4fc3-b8a2-8a6368f13859", "6e8ea4fa-6d44-4ab8-99f5-503524808fb1", "Admin", "admin" }
                });
        }
    }
}
