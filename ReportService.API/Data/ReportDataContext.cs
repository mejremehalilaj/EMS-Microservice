using Microsoft.EntityFrameworkCore;
using ReportService.API.Models;

namespace ReportService.API.Data
{
    public class ReportDataContext : DbContext
    { 
        public ReportDataContext(DbContextOptions<ReportDataContext> options) : base(options)
        {

        }

        public DbSet<StudentPerformance> StudentsPerformance { get; set; }
    }
}
