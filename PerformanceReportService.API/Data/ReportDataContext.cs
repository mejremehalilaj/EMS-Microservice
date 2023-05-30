using Microsoft.EntityFrameworkCore;
using PerformanceReportService.API.Models;
using System.Linq;

namespace PerformanceReportService.API.Data
{
    public class ReportDataContext : DbContext
    { 
        public ReportDataContext(DbContextOptions<ReportDataContext> options) : base(options)
        {

        }

        public DbSet<Performance> Performance { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
