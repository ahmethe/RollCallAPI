using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UsersController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _manager.UserService.GetAllUsers(false);
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser([FromRoute(Name = "id")] int id)
        {
            var user = _manager
                .UserService
                .GetOneUserById(id, false);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateOneUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest();

            _manager.UserService.CreateOneUser(user);

            return StatusCode(201, user);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneUser([FromBody] User user, 
            [FromRoute(Name = "id")]int id)
        {
            if (user is null)
                return BadRequest();

            _manager.UserService.UpdateOneUser(id, user, true);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneUser([FromRoute(Name = "id")] int id)
        {
            _manager.UserService.DeleteOneUser(id, false);

            return NoContent();
        }
    }
}
