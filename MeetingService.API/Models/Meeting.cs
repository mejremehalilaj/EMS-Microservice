using System;
using System.Collections.Generic;

namespace MeetingService.API.Models
{
    public partial class Meeting
    {
        public string Id { get; set; } = null!;
        public string? Title { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public bool? Online { get; set; }
    }
}
