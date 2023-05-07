﻿// <auto-generated />
using System;
using MeetingService.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetingService.API.Migrations
{
    [DbContext(typeof(MeetingDBContext))]
    [Migration("20230507181514_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MeetingService.API.Models.Meeting.Meetings", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("MeetingService.API.Models.Meeting.MeetingUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "UserId");

                    b.ToTable("MeetingUsers");
                });

            modelBuilder.Entity("MeetingUserMeetings", b =>
                {
                    b.Property<string>("MeetingsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MeetingUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MeetingUsersUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MeetingsId", "MeetingUsersId", "MeetingUsersUserId");

                    b.HasIndex("MeetingUsersId", "MeetingUsersUserId");

                    b.ToTable("MeetingUserMeetings");
                });

            modelBuilder.Entity("MeetingUserMeetings", b =>
                {
                    b.HasOne("MeetingService.API.Models.Meeting.Meetings", null)
                        .WithMany()
                        .HasForeignKey("MeetingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingService.API.Models.Meeting.MeetingUser", null)
                        .WithMany()
                        .HasForeignKey("MeetingUsersId", "MeetingUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
