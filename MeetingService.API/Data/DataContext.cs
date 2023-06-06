using Microsoft.EntityFrameworkCore;

namespace MeetingService.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<MeetingService> MeetingsUser { get; set; }  
        public DbSet<MeetingUser> MeetingUsers { get; set; }
    }
}
