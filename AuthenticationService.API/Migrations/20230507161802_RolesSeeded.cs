using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationService.API.Migrations
{
    public partial class RolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09bb1d73-6e23-4496-95df-a27c969284b1", "4", "Teacher", "Teacher" },
                    { "2895c634-77ef-4d97-ad96-9cbc4d314bbe", "3", "Parent", "Parent" },
                    { "2f953fb2-38e1-4134-a5d0-f6adb1bd1456", "1", "Admin", "Admin" },
                    { "dc878243-6490-4db7-a44e-4b5597e07246", "2", "User", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bb1d73-6e23-4496-95df-a27c969284b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2895c634-77ef-4d97-ad96-9cbc4d314bbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f953fb2-38e1-4134-a5d0-f6adb1bd1456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc878243-6490-4db7-a44e-4b5597e07246");
        }
    }
}
