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
    public class ExamController : ControllerBase
    {
        IExam _examService;
        public ExamController(IExam examService)
        {
            _examService = examService;
        }

        // GET api/Exam/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_examService.GetExam(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting exam data. Check logs for details.");
            }
        }

        // GET api/Exam/User/5
        [HttpGet("User/{id}")]
        public IActionResult GetByUser(string id)
        {
            try
            {
                return Ok(_examService.GetExamsByUser(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting user exam data. Check logs for details.");
            }
        }

        // POST api/Exam
        [HttpPost]
        public IActionResult Post([FromBody] Exam exam)
        {
            try
            {
                return Ok(_examService.CreateExam(exam));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error creating exam. Check logs for details.");
            }
        }

        // PUT api/Exam
        [HttpPut]
        public IActionResult Put([FromBody] Exam exam)
        {
            try
            {
                return Ok(_examService.UpdateExam(exam));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating exam. Check logs for details.");
            }
        }

        // DELETE api/Exam/6516516
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_examService.DeleteExam(id));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error deleting exam. Check logs for details.");
            }
        }
    }
}
