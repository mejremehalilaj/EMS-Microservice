using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceReportService.API.Models;
using System.Collections.Generic;

namespace PerformanceReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ReportDataContext _reportDataContext;
        public EmployeeController(ReportDataContext reportDataContext)
        {
            _reportDataContext = reportDataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> getEmployee()
        {
            if (_reportDataContext.Employees == null)
            {
                return NotFound();
            }
            return await _reportDataContext.Employees.ToListAsync();

        }

        //IEnumerable osht qe i merr list nja ka nja mdoket perqata se kom perdor qetu
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> getEmployees(int id)
        {
            if (_reportDataContext.Employees == null)
            {
                return NotFound();
            }
            var employee = _reportDataContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
            //return await _reportDataContext.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> postEmployees(Employee employee)
        {
            _reportDataContext.Employees.Add(employee);
            await _reportDataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(getEmployees), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(int id, Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }

            _reportDataContext.Entry(employee).State = EntityState.Modified;
            try 
            {
                await _reportDataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();   
        }


        [HttpDelete("id")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if(_reportDataContext.Employees == null)
            {
                return NotFound();
            }
            var employee = await _reportDataContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            _reportDataContext.Employees.Remove(employee);
            await _reportDataContext.SaveChangesAsync();
            return Ok();
        }

    }
}
