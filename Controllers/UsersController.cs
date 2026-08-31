using FrameSeen.Dtos;
using FrameSeen.Models;
using FrameSeen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = service.ValidateUser(request.Email, request.Password);
    
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            string token = tokenProvider.CreateToken(user);
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRequest request)
        {
            UserResponse response = service.AddUsers(request);

            return Ok(response);
            
        }

        [Authorize]

        [HttpGet]
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

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]User serie)
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
        [Authorize(Policy = "AdminOnly")]
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