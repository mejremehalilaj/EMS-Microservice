using Microsoft.EntityFrameworkCore;
using PerformanceReportService.API.Models;

namespace PerformanceReportService.API.Data
{
    public class ReportDataContext : DbContext
    { 
        public ReportDataContext(DbContextOptions<ReportDataContext> options) : base(options)
        {

        }

        public DbSet<Performance> Performance { get; set; }
    }
}
