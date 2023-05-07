using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingService.API.Models.Meeting
{
    public class MeetingUser
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Meetings> Meetings { get; set; }
        [NotMapped] // Ignore the UserId property
        public string UserId { get; internal set; }
    }
}
