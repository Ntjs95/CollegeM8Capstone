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
    public class SleepController : Controller
    {
        ISleepLogic _sleepLogic;

        public SleepController(ISleepLogic sleepLogic)
        {
            _sleepLogic = sleepLogic;
        }

        // GET api/Sleep/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_sleepLogic.GetSleep(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting sleep data. Check logs for details.");
            }
        }

        // POST api/Sleep
        [HttpPost]
        public IActionResult Post([FromBody] Sleep sleep)
        {
            try
            {
                return Ok(_sleepLogic.CreateSleep(sleep));
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
        
        // PUT api/Sleep
        [HttpPut]
        public IActionResult Put([FromBody] Sleep sleep)
        {
            try
            {
                return Ok(_sleepLogic.UpdateSleep(sleep));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating sleep data. Check logs for details.");
            }
        }



    }
}
