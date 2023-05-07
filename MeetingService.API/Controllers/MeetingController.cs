using MeetingService.API.Models.Meeting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {


        private readonly MeetingDBContext _dbContext;

        public MeetingController(MeetingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meetings>>> GetMeetings()
        {
            var meetings = await _dbContext.Meetings.ToListAsync();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meetings>> GetMeeting(string id)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        [HttpGet]
        [Route("MeetingUser")]
        public async Task<ActionResult<IEnumerable<MeetingUser>>> GetMeetingUsers()
        {
            var meetingUsers = await _dbContext.MeetingUsers.ToListAsync();
            return Ok(meetingUsers);
        }

        [HttpGet("{id}")]
        [Route("MeetingUser")]
        public async Task<ActionResult<MeetingUser>> GetMeetingUser(string id)
        {
            var meetingUser = await _dbContext.MeetingUsers.FindAsync(id);

            if (meetingUser == null)
            {
                return NotFound();
            }

            return Ok(meetingUser);
        }


        [HttpPut("api/meetings/{id}")]
        public IActionResult UpdateMeeting(string id, [FromBody] Meetings meeting)
        {
            var existingMeeting = _dbContext.Meetings.FirstOrDefault(m => m.Id == id);

            if (existingMeeting == null)
            {
                return NotFound();
            }

            // Update the meeting object with the new data
            existingMeeting.Title = meeting.Title;
            existingMeeting.StartTime = meeting.StartTime;
            existingMeeting.EndTime = meeting.EndTime;
            existingMeeting.Place = meeting.Place;
            existingMeeting.Description = meeting.Description;
            existingMeeting.Online = meeting.Online;

            _dbContext.SaveChanges();

            return NoContent();
        }
    }

    [HttpDelete("api/meetings/{id}")]
    public IActionResult DeleteMeeting(string id)
    {
        var meeting = _dbContext.Meetings.Find(id);

        if (meeting == null)
        {
            return NotFound();
        }

        _dbContext.Meetings.Remove(meeting);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
