using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeetingService.API.Models
{
    public partial class MeetingDBContext : DbContext
    {
        public MeetingDBContext()
        {
        }

        public MeetingDBContext(DbContextOptions<MeetingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<MeetingUser> MeetingUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AGON\\SQLEXPRESS;Database=MeetingDB;Trusted_Connection=True;");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("Meeting");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.Online).HasColumnName("online");

                entity.Property(e => e.Place)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<MeetingUser>(entity =>
            {
                entity.ToTable("MeetingUser");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
