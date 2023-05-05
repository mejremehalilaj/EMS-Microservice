using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthService.API.Services.Meeting
{
    public class MeetingService : IMeetingService
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public bool Online { get; set; }
        public MeetingStatus CreatedByStatus { get; set; }
        public MeetingUser CreatedByUser { get; set; }
        public MeetingUser InvitedUser { get; set; }
        public string Comment { get; set; }


        /* id:String
         title:String
         start_time:Timestamp
         end_time:Timestamp
         place:String
         description:String
         online:boolean
         createdBy:MeetingStatus
         createdBy:MeetingUser
         invitedUser:MeetingUser
         comment:String*/
        public IEnumerable<MeetingService> GetAllMeetings()
        {
            return _meetings;
        }

    }
}
