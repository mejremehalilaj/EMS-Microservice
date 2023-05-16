using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportServiceController : ControllerBase
    {
        private readonly ReportDataContext _context;

        public ReportServiceController(ReportDataContext context)
        {
            _context = context;
        }

        /******** Student Perfomance *********/
        //get all
        [HttpGet]
        public async Task<ActionResult<List<StudentPerformance>>> GetMeetingService()
        {
            return Ok(await _context.StudentsPerformance.ToListAsync());
        }

    }
}
