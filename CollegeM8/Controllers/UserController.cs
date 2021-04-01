using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CollegeM8
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class UserController : ControllerBase
    {
        private IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(string id, bool expand = false)
        {
            try
            {
                return Ok(_userLogic.GetUser(id, expand));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            } catch (Exception)
            {
                return BadRequest("Error getting user. Check logs for details.");
            }
        }

        // POST api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                return Ok(_userLogic.CreateUser(user));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Error creating user. Check logs for details. " + e.Message);
            }
        }

        // PUT api/User
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                return Ok(_userLogic.UpdateUser(user));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error updating user. Check logs for details.");
            }
        }

        // POST api/User
        [HttpPost("login")]
        public IActionResult PostLogin([FromBody] Login login)
        {
            try
            {
                return Ok(_userLogic.Login(login));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Login Error. Check logs for details.");
            }
        }
        
        // POST api/User
        [HttpPost("changepassword")]
        public IActionResult PostChangePassword([FromBody] ChangePassword login)
        {
            try
            {
                return Ok(_userLogic.ChangePassword(login));
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Password Error. Check logs for details.");
            }
        }

        // GET api/User/5
        [HttpGet("nextevent/{id}")]
        public IActionResult GetNextEvent(string id)
        {
            try
            {
                NextEvent ev = _userLogic.GetNextEvent(id);
                return Ok(ev);
            }
            catch (ServiceException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error getting next event. Check logs for details.");
            }
        }
    }
}
