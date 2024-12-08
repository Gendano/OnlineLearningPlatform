using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class updateprofile23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "17fc88a7-2d2a-45cb-ad8f-9e71d5a88b55", "1baef7ea-3af7-4cd2-b440-a0bd7c18ff4e", "Teacher", "teacher" },
                    { "6032c961-d2c3-44e4-a766-01ecd7459c1b", "e5d5b7ba-d144-40b1-b210-d59bb317eae6", "User", "user" },
                    { "7aba9479-9307-49bb-8317-19d356349c45", "437509e2-32a5-4380-abcd-96b8e825a9a3", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1d48939f-70f5-4662-86b5-2c9f0bcba6da", "ff04c731-b418-4f27-ad13-2377cd36952e", "User", "user" },
                    { "208410bc-1d55-4021-84ff-5b9a3220d85f", "883ca204-9229-4b6d-82de-653a360a4e72", "Teacher", "teacher" },
                    { "f30ddbbe-cfbc-4b71-93ca-ed192c5a9886", "8d026692-7eb5-4ed8-9bf2-2ce6cbd2cb1c", "Admin", "admin" }
                });
        }
    }
}
