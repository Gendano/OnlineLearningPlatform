using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sacafoldinh1.Migrations
{
    /// <inheritdoc />
    public partial class editfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "376fb20e-2184-4a32-8584-b2fc82aef9a2", "a3fec381-2975-4224-a8fa-9f6936a1ed59", "Admin", "admin" },
                    { "5d61eb7b-d6c3-45e2-a77c-7cdd8355fed6", "7720042f-ab76-49df-bbeb-ca82bcf85d2a", "User", "user" },
                    { "c0b5f29c-5c95-4db9-98a0-34ec8040a12e", "1a8b7eda-19f8-41ab-92d3-ac11a63a9791", "Teacher", "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "376fb20e-2184-4a32-8584-b2fc82aef9a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d61eb7b-d6c3-45e2-a77c-7cdd8355fed6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b5f29c-5c95-4db9-98a0-34ec8040a12e");

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
    }
}
