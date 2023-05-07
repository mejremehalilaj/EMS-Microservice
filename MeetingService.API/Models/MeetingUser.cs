using System;
using System.Collections.Generic;

namespace MeetingService.API.Models
{
    public partial class MeetingUser
    {
        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
