using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingUserController : ControllerBase
    {
        private readonly DataContext _context;
        public MeetingUserController(DataContext context)
        {
            _context = context;
        }

        /******** MEETING USER *********/
         //get all
         [HttpGet]
         public async Task<ActionResult<List<MeetingUser>>> GetAllMeetingUser()
         {
             return Ok(await _context.MeetingUsers.ToListAsync());
         }

        //nese dojm me marr p.sh veq nje takim me Id
        [HttpGet("{Id}")]
        public async Task<ActionResult<MeetingUser>> Get(string Id)
        {
            var meet = await _context.MeetingUsers.FindAsync(Id);
            if (meet == null)
                return BadRequest("Meetings not found");
            return Ok(meet);
        }

        //me shtu meetings
        [HttpPost]
        public async Task<ActionResult<List<MeetingUser>>> AddMettingUser(MeetingUser users)
        {
            _context.MeetingUsers.Add(users);
            await _context.SaveChangesAsync();
            return Ok(await _context.MeetingUsers.ToListAsync());
        }

        //me ndrru Meeting te dhenat
        [HttpPut]
        public async Task<ActionResult<List<MeetingUser>>> UpdateMeetingUser(MeetingUser request)
        {
            var dbUser = await _context.MeetingUsers.FindAsync(request.Id);
            if (dbUser == null)
                return BadRequest("Meetings not found");

            dbUser.Id = request.Id;
            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
           

            await _context.SaveChangesAsync();

            return Ok(await _context.MeetingUsers.ToListAsync());
        }

        //mi fshi user
        [HttpDelete("Id")]
        public async Task<ActionResult<List<MeetingUser>>> DeleteMeeting(string Id)
        {
            var dbUser = await _context.MeetingUsers.FindAsync(Id);
            if (dbUser == null)
                return BadRequest("Users not found");

            _context.MeetingUsers.Remove(dbUser);

            await _context.SaveChangesAsync();
            return Ok(await _context.MeetingUsers.ToListAsync());
        }


    }
}
