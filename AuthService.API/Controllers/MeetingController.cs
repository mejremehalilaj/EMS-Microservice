using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    public class MeetingController : Controller
    {

        private readonly List<MeetingController> _meetings = new List<MeetingController>();

        public IEnumerable<MeetingController> GetAllMeetings()
        {
            return _meetings;
        }

        
     
        
    }
}
