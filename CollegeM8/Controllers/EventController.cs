using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeM8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventLogic _eventLogic;
        public EventController(IEventLogic eventLogic)
        {
            _eventLogic = eventLogic;
        }

        // GET api/Event/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_eventLogic.GetEvent(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting event. Check logs for details.");
            }
        }

        // POST api/Event
        [HttpPost]
        public IActionResult Post([FromBody] Event schedEvent)
        {
            try
            {
                return Ok(_eventLogic.CreateEvent(schedEvent));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating event. Check logs for details.");
            }
        }

        // GET api/Event/User/5
        [HttpGet("User/{userId}")]
        public IActionResult GetByUser(string userId)
        {
            try
            {
                return Ok(_eventLogic.GetEventsByUser(userId));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting event. Check logs for details.");
            }
        }
    }
}
