using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CollegeM8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class ScheduleController : ControllerBase
    {
        public ISchedule _scheduleService { get; }
        public ScheduleController(ISchedule scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET api/Schedule/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // Get api/Schedule
        [HttpGet]
        public IActionResult GetSchedule([FromBody] Schedule value)
        {
            try
            {
                return Ok(_scheduleService.GenerateSchedule(value));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating sleep data. Check logs for details.");
            }
        }
    }
}
