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
    public class TermController : ControllerBase
    {
        ITerm _termService;
        public TermController(ITerm termService)
        {
            _termService = termService;
        }

        // GET api/Term/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_termService.GetTerm(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting term data. Check logs for details.");
            }
        }

        // GET api/Term/User/5
        [HttpGet("User/{id}")]
        public IActionResult GetByUser(string id)
        {
            try
            {
                return Ok(_termService.GetTermByUser(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting user term data. Check logs for details.");
            }
        }

        // POST api/Term
        [HttpPost]
        public IActionResult Post([FromBody] Term term)
        {
            try
            {
                return Ok(_termService.CreateTerm(term));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating term. Check logs for details.");
            }
        }

        // PUT api/Term
        [HttpPut]
        public IActionResult Put([FromBody] Term term)
        {
            try
            {
                return Ok(_termService.UpdateTerm(term));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating term. Check logs for details.");
            }
        }

        // DELETE api/Term/6516516
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_termService.DeleteTerm(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error deleting term. Check logs for details.");
            }
        }
    }
}
