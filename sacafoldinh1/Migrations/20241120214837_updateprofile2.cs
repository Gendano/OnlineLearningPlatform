using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class updateprofile2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d48939f-70f5-4662-86b5-2c9f0bcba6da", "ff04c731-b418-4f27-ad13-2377cd36952e", "User", "user" },
                    { "208410bc-1d55-4021-84ff-5b9a3220d85f", "883ca204-9229-4b6d-82de-653a360a4e72", "Teacher", "teacher" },
                    { "f30ddbbe-cfbc-4b71-93ca-ed192c5a9886", "8d026692-7eb5-4ed8-9bf2-2ce6cbd2cb1c", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d48939f-70f5-4662-86b5-2c9f0bcba6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "208410bc-1d55-4021-84ff-5b9a3220d85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f30ddbbe-cfbc-4b71-93ca-ed192c5a9886");

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
                    { "04403d77-2ae7-4949-9eb1-f00188e4b439", "b02340ea-588b-4488-b34a-90d8a61bf588", "User", "user" },
                    { "a00df0e9-f26c-4350-9a6d-28bb35123b01", "4a745eb2-d6d4-4d73-999e-721cfce7c1d7", "Admin", "admin" },
                    { "f6f990f5-72c0-4a61-bc0f-13fbbf02d5d9", "d4365a44-c29b-404e-9ec6-c54253bad4fb", "Teacher", "teacher" }
                });
        }
    }
}
