using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class userdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04403d77-2ae7-4949-9eb1-f00188e4b439", "b02340ea-588b-4488-b34a-90d8a61bf588", "User", "user" },
                    { "a00df0e9-f26c-4350-9a6d-28bb35123b01", "4a745eb2-d6d4-4d73-999e-721cfce7c1d7", "Admin", "admin" },
                    { "f6f990f5-72c0-4a61-bc0f-13fbbf02d5d9", "d4365a44-c29b-404e-9ec6-c54253bad4fb", "Teacher", "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04403d77-2ae7-4949-9eb1-f00188e4b439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a00df0e9-f26c-4350-9a6d-28bb35123b01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6f990f5-72c0-4a61-bc0f-13fbbf02d5d9");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
