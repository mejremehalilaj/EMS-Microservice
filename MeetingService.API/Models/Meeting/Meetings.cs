using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingService.API.Models.Meeting
{
    public class Meetings
    {
        [Key]
        public string Id { get; set; }
        public string? Title { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public bool? Online { get; set; }

        public ICollection<MeetingUser> MeetingUsers { get; set; }
    }
}
