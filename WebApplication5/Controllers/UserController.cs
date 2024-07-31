using Microsoft.AspNetCore.Mvc;
using WebApplication5.Entity;
using WebApplication5.Repositories;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            User createdUser = null;
            try
            {
                createdUser = await _userService.CreateUser(user);

                if (createdUser is null) { 
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                
                _logger.LogError("UserController.CreateUser " + ex);
            }

            return Ok(createdUser);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            User updatedUser = null;
            try
            {
                updatedUser = await _userService.UpdateUser(user);
                if(updatedUser is null)
                {
                    return StatusCode(500);
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError("UserController.CreateUser " + ex);
            }
            return Ok(updatedUser);
            
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<User>> getAllUser()
        {
            return await _userService.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<List<User>> GetUserByID([FromRoute] int id)
        //{
        //    //return _userService.GetUserById(id);
        //}
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] int id)
        {
            _userService.DeleteById(id);

        }

    }
}

