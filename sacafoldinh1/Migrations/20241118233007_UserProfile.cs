using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class UserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31f12f7c-a7d6-4de4-8f7f-52dfcb15d6be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "842806bb-451a-4e6a-a5ef-9452f722c6f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfc5313d-e813-4b94-a1c7-7b7b59735e00");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "240ee101-f597-4282-8e7e-ee7b8beaeba1", "1c21350e-4c29-40a9-ae55-46d2ef6514a3", "Admin", "admin" },
                    { "a8d9bfab-13b4-4897-b026-5928b626172b", "1a44f588-9fbd-491e-a991-da8ec0e02887", "Teacher", "teacher" },
                    { "e2785993-3f99-4326-a2a5-74b69778a738", "adee7a1c-e999-42c2-ae9a-4788a0b2060f", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "240ee101-f597-4282-8e7e-ee7b8beaeba1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8d9bfab-13b4-4897-b026-5928b626172b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2785993-3f99-4326-a2a5-74b69778a738");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31f12f7c-a7d6-4de4-8f7f-52dfcb15d6be", "ebea1739-84ec-492b-aba0-8cdea71c9fd9", "Admin", "admin" },
                    { "842806bb-451a-4e6a-a5ef-9452f722c6f5", "189c6b0c-7def-40fb-bcfc-f8d082610fbd", "Teacher", "teacher" },
                    { "bfc5313d-e813-4b94-a1c7-7b7b59735e00", "71b9372c-1a40-42ad-ac42-f141dd5ca453", "User", "user" }
                });
        }
    }
}
