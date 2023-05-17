using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PerformanceReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReportServiceController : ControllerBase
    {
        private readonly ReportDataContext _context;

        public PerformanceReportServiceController(ReportDataContext context)
        {
            _context = context;
        }

        /******** Student Performance *********/
        //get all
        [HttpGet]
        public async Task<ActionResult<List<Performance>>> GetPerformance()
        {
            return Ok(await _context.Performance.ToListAsync());
        }

        //nese dojm me marr p.sh veq nje Student me Id
        [HttpGet("{StudentId}")]
        public async Task<ActionResult<Performance>> Get(string StudentId)
        {
            var meet = await _context.Performance.FindAsync(StudentId);
            if (meet == null)
                return BadRequest("Report for performance not found");
            return Ok(meet);
        }

        //me shtu meetings
        [HttpPost]
        public async Task<ActionResult<List<Performance>>> AddPerformance(Performance Performance)
        {
            _context.Performance.Add(Performance);
            await _context.SaveChangesAsync();
            return Ok(await _context.Performance.ToListAsync());
        }

        //me ndrru Performance te dhenat
        [HttpPut]
        public async Task<ActionResult<List<Performance>>> UpdatePerformance(Performance request)
        {
            var dbReport = await _context.Performance.FindAsync(request.Id);
            if (dbReport == null)
                return BadRequest("Report for Performance not found");

            dbReport.Id = request.Id;
            dbReport.PerformanceIndex = request.PerformanceIndex;
            dbReport.StudentId = request.StudentId;
            dbReport.DateGenerated = request.DateGenerated;

            await _context.SaveChangesAsync();

            return Ok(await _context.Performance.ToListAsync());
        }

        //mi fshi performance
        [HttpDelete("Id")]
        public async Task<ActionResult<List<Performance>>> DeletePerformance(string Id)
        {
            var dbMeet = await _context.Performance.FindAsync(Id);
            if (dbMeet == null)
                return BadRequest("Meetings not found");

            _context.Performance.Remove(dbMeet);

            await _context.SaveChangesAsync();
            return Ok(await _context.Performance.ToListAsync());
        }
    }
}
