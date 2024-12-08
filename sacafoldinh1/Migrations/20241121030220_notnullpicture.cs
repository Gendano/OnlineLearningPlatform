using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class notnullpicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17fc88a7-2d2a-45cb-ad8f-9e71d5a88b55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6032c961-d2c3-44e4-a766-01ecd7459c1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aba9479-9307-49bb-8317-19d356349c45");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "17fc88a7-2d2a-45cb-ad8f-9e71d5a88b55", "1baef7ea-3af7-4cd2-b440-a0bd7c18ff4e", "Teacher", "teacher" },
                    { "6032c961-d2c3-44e4-a766-01ecd7459c1b", "e5d5b7ba-d144-40b1-b210-d59bb317eae6", "User", "user" },
                    { "7aba9479-9307-49bb-8317-19d356349c45", "437509e2-32a5-4380-abcd-96b8e825a9a3", "Admin", "admin" }
                });
        }
    }
}
