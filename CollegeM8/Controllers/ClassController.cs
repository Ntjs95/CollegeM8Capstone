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
    public class ClassController : ControllerBase
    {
        IClass _classService;
        public ClassController(IClass classService)
        {
            _classService = classService;
        }

        // GET api/Class/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_classService.GetClass(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting class data. Check logs for details.");
            }
        }

        // POST api/Class
        [HttpPost]
        public IActionResult Post([FromBody] Class _class)
        {
            try
            {
                return Ok(_classService.CreateClass(_class));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating class. Check logs for details.");
            }
        }

        // PUT api/Class
        [HttpPut]
        public IActionResult Put([FromBody] Class _class)
        {
            try
            {
                return Ok(_classService.UpdateClass(_class));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating class. Check logs for details.");
            }
        }

        // DELETE api/Class/6516516
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_classService.DeleteClass(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error deleting class. Check logs for details.");
            }
        }
    }
}
