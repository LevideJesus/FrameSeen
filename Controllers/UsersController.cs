using FrameSeen.Dtos;
using FrameSeen.Models;
using FrameSeen.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;
        private readonly TokenProvider tokenProvider;

        public UsersController(IUserService userService, TokenProvider tokenProvider)
        {
            service = userService;
            this.tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            string token = tokenProvider.CreateToken(user);

            return Ok(new {Token = token});
        }


        [HttpGet()]
        public IActionResult GetUsers()
        {

            return Ok(service.GetAllUsers());
        }

        [HttpGet ("{id}")]
  
        public IActionResult GetUsersById(int id)
        {
            var response = service.GetUsersById(id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]

        public IActionResult CreateUser(UserRequest user)
        {
            var createdUser = service.AddUsers(user);
            return CreatedAtAction(nameof(GetUsersById), new {id = createdUser.Id}, createdUser);
        }

        [HttpPut("{id}")]
        

        public IActionResult UpdateUser(int id, User serie)
        {
            try
            {
                service.UpdateUsers(id, serie);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
            

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                service.DeleteUsers(id);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}