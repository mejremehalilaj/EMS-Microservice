using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceReportService.API.Models;
using System.Linq;

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
        [HttpGet("{Id}")]
        public async Task<ActionResult<Performance>> Get(string Id)
        {
            var report = await _context.Performance.FindAsync(Id);
            if (report == null)
                return BadRequest("Report for performance not found");
            return Ok(report);
        }

        //me shtu meetings
        [HttpPost]
        public async Task<ActionResult<List<Performance>>> AddPerformance(Performance performancereport)
        {
            _context.Performance.Add(performancereport);
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
            var dbReport = await _context.Performance.FindAsync(Id);
            if (dbReport == null)
                return BadRequest("Meetings not found");

            _context.Performance.Remove(dbReport);

            await _context.SaveChangesAsync();
            return Ok(await _context.Performance.ToListAsync());
        }

       /* [HttpGet("{studentId}")]
        public ActionResult<Performance> GetStudentPerformance(string studentId)
        {
            var studentPerformance = Performance.AsEnumerable().FirstOrDefault(sp => sp.StudentId == studentId);
                
            if (studentPerformance == null)
            {
                return NotFound();
            }

            return Ok(studentPerformance);
        }*/
    }
}
