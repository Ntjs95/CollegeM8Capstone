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
    public class AssignmentController : ControllerBase
    {
        IAssignment _assignmentService;
        public AssignmentController(IAssignment assignmentService)
        {
            _assignmentService = assignmentService;
        }

        // GET api/Assignment/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_assignmentService.GetAssignment(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting assignment data. Check logs for details.");
            }
        }

        // GET api/Assignment/User/5
        [HttpGet("User/{id}")]
        public IActionResult GetByUser(string id)
        {
            try
            {
                return Ok(_assignmentService.GetAssignmentByUser(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting user assignment data. Check logs for details.");
            }
        }

        // POST api/Assignment
        [HttpPost]
        public IActionResult Post([FromBody] Assignment assignment)
        {
            try
            {
                return Ok(_assignmentService.CreateAssignment(assignment));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating assignment. Check logs for details.");
            }
        }

        // PUT api/Assignment
        [HttpPut]
        public IActionResult Put([FromBody] Assignment assignment)
        {
            try
            {
                return Ok(_assignmentService.UpdateAssignment(assignment));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating assignment. Check logs for details.");
            }
        }

        // DELETE api/Assignment/6516516
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_assignmentService.DeleteAssignment(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error deleting assignment. Check logs for details.");
            }
        }
    }
}
