using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportService.API.Migrations
{
    public partial class CreateStudentPerfomance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsPerformance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PerformanceIndex = table.Column<float>(type: "real", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsPerformance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsPerformance");
        }
    }
}
