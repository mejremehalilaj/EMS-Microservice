using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment.Service.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38c66625-363f-4dc8-851d-47ff36b1dcd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5758695d-c77a-4e7f-9289-57367a5e7754");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59cb143c-a3c1-4fb6-bff9-69fa4b89913b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d35c556d-2172-43bb-a032-b43ae44670e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea11e7de-1af2-404b-8813-b69b08224268");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06808483-b30b-4aa6-b834-6fb28b75254a", "2", "User", "User" },
                    { "50245036-be13-4ff4-9b50-d32233620705", "1", "Admin", "Admin" },
                    { "6d6c5013-5ae3-467d-8b59-f0ee53214cde", "3", "Student", "Student" },
                    { "896a1420-5d20-4552-b35e-9a5913a8b3ff", "5", "Teacher", "Teacher" },
                    { "8ac119b0-4e41-4ce1-944a-9f3215390617", "4", "Parent", "Parent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06808483-b30b-4aa6-b834-6fb28b75254a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50245036-be13-4ff4-9b50-d32233620705");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6c5013-5ae3-467d-8b59-f0ee53214cde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "896a1420-5d20-4552-b35e-9a5913a8b3ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac119b0-4e41-4ce1-944a-9f3215390617");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38c66625-363f-4dc8-851d-47ff36b1dcd4", "4", "Parent", "Parent" },
                    { "5758695d-c77a-4e7f-9289-57367a5e7754", "1", "Admin", "Admin" },
                    { "59cb143c-a3c1-4fb6-bff9-69fa4b89913b", "3", "Student", "Student" },
                    { "d35c556d-2172-43bb-a032-b43ae44670e4", "2", "User", "User" },
                    { "ea11e7de-1af2-404b-8813-b69b08224268", "5", "Teacher", "Teacher" }
                });
        }
    }
}
