using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bfc19f1-331e-46b9-b1af-03e675a607b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4fe8ad7-bde5-4e09-a8d8-f21b04b4a6b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd8b4994-64a6-4619-a3a9-4ab03496afc0");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27b27064-38af-4b04-861f-99d527969a7d", "1394070e-724b-4bff-9d0d-595085fe96bb", "Teacher", "teacher" },
                    { "9e253fc3-1d1f-4c97-b85f-dcbf5871349c", "4142a648-03fe-43cf-85d3-056bb6f9536d", "User", "user" },
                    { "dfdbb3c3-b2f8-4934-a5f0-d05f02ec3a7b", "ded56e76-4ead-40fa-b4a8-372f8c23fdff", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27b27064-38af-4b04-861f-99d527969a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e253fc3-1d1f-4c97-b85f-dcbf5871349c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfdbb3c3-b2f8-4934-a5f0-d05f02ec3a7b");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bfc19f1-331e-46b9-b1af-03e675a607b6", "3401d86f-b1e7-475c-825c-fe4c7f1f21db", "User", "user" },
                    { "c4fe8ad7-bde5-4e09-a8d8-f21b04b4a6b7", "053b602c-7285-43ac-9d83-03efdeb37a99", "Admin", "admin" },
                    { "dd8b4994-64a6-4619-a3a9-4ab03496afc0", "a0e191e3-0503-40f8-9c22-4ed53d2a6dc3", "Teacher", "teacher" }
                });
        }
    }
}
