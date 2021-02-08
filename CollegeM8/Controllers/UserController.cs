using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CollegeM8
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserLogic _userLogic;
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_userLogic.GetUser(id));
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
            catch (Exception)
            {
                return BadRequest("Error creating user. Check logs for details.");
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
    }
}
