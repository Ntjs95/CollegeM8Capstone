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
    public class ScheduleItemController : Controller
    {
        IScheduleItem _scheduleItem;

        public ScheduleItemController(IScheduleItem scheduleItem)
        {
            _scheduleItem = scheduleItem;
        }

        // GET api/ScheduleItem/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_scheduleItem.GetScheduleItem(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting schedule item data. Check logs for details.");
            }
        }

        // POST api/ScheduleItem
        [HttpPost]
        public IActionResult Post([FromBody] ScheduleItem scheduleItem)
        {
            try
            {
                return Ok(_scheduleItem.CreateScheduleItem(scheduleItem));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating schedule item. Check logs for details.");
            }
        }

        // PUT api/ScheduleItem
        [HttpPut]
        public IActionResult Put([FromBody] ScheduleItem scheduleItem)
        {
            try
            {
                return Ok(_scheduleItem.UpdateScheduleItem(scheduleItem));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating schedule item. Check logs for details.");
            }
        }
        
        // DELETE api/ScheduleItem/6516516
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_scheduleItem.DeleteScheduleItem(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error deleting item. Check logs for details.");
            }
        }



    }
}
