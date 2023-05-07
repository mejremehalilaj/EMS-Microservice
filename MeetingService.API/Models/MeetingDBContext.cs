using Microsoft.EntityFrameworkCore;
using MeetingService.API.Models.Meeting;
namespace MeetingService.API.Models
{
    public class MeetingDBContext : DbContext
    {
        public MeetingDBContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Meetings> Meetings { get; set; }
        public DbSet<MeetingUser> MeetingUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetings>().HasKey(m => m.Id);
            modelBuilder.Entity<MeetingUser>().HasKey(mu => new { mu.Id, mu.UserId });
                                                                          //meetingID
        }
    }
   
}
