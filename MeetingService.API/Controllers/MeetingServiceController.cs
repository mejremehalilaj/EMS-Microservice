using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingServiceController : ControllerBase
    {
        private readonly DataContext _context;
        public MeetingServiceController(DataContext context)
        {
            _context = context;
        }


        /******** MEETING *********/
        //get all
        [HttpGet]
        public async Task<ActionResult<List<MeetingService>>> GetMeetingService()
        {
            return Ok(await _context.MeetingsUser.ToListAsync());
        }

        //nese dojm me marr p.sh veq nje takim me Id
        [HttpGet("{Id}")]
        public async Task<ActionResult<MeetingService>> Get(string Id)
        {
            var meet = await _context.MeetingsUser.FindAsync(Id);
            if (meet == null)
                return BadRequest("Meetings not found");
            return Ok(meet);
        }

        //me shtu meetings
        [HttpPost]
        public async Task<ActionResult<List<MeetingService>>> AddMetting(MeetingService meeting)
        {
            _context.MeetingsUser.Add(meeting);
            await _context.SaveChangesAsync();
            return Ok(await _context.MeetingsUser.ToListAsync());
        }

        //me ndrru Meeting te dhenat
        [HttpPut]
        public async Task<ActionResult<List<MeetingService>>> UpdateMeeting(MeetingService request)
        {
            var dbMeet = await _context.MeetingsUser.FindAsync(request.Id);
            if (dbMeet == null)
                return BadRequest("Meetings not found");

            dbMeet.Id = request.Id;
            dbMeet.Title = request.Title;
            dbMeet.StartTime = request.StartTime;
            dbMeet.EndTime = request.EndTime;
            dbMeet.Place = request.Place;
            dbMeet.Description = request.Description;
            dbMeet.Online = request.Online;

            await _context.SaveChangesAsync();

            return Ok(await _context.MeetingsUser.ToListAsync());
        }

        //mi fshi meeting
        [HttpDelete("Id")]
        public async Task<ActionResult<List<MeetingService>>> DeleteMeeting(string Id)
        {
            var dbMeet = await _context.MeetingsUser.FindAsync(Id);
            if (dbMeet == null)
                return BadRequest("Meetings not found");

            _context.MeetingsUser.Remove(dbMeet);

            await _context.SaveChangesAsync();
            return Ok(await _context.MeetingsUser.ToListAsync());
        }


        
    }
}
