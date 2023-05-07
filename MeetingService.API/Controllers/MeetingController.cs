using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MeetingService.API.Models;

namespace MeetingService.API.Controllers
{
    public class MeetingController : Controller
    {

        private readonly ILogger<MeetingController> _logger;
        private readonly MeetingDBContext _dbContext;
        public MeetingController(ILogger<MeetingController> logger, MeetingDBContext _dBContext)
        {
            _logger = logger;
            this._dbContext = _dbContext;
        }


        [HttpGet("api/meeting")]
        public IActionResult GetMeetings()
        {
            try
            {
                var meetings = _dbContext.MeetingUsers.ToList();
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the meetings.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
/*
        [HttpGet]
        public IActionResult Index()
        {
            var costumer = _dbContext.MeetingUsers.ToList();
            return View();
        }*/
    }
}
