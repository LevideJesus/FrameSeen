using FrameSeen.Dtos;
using FrameSeen.Models;
using FrameSeen.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
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

        public IActionResult CreateSerie(UserRequest user)
        {
            var createdUser = service.AddUsers(user);
            return CreatedAtAction(nameof(GetUsersById), new {id = createdUser.Id}, createdUser);
        }

        [HttpPut("{id}")]
        

        public IActionResult UpdateSerie(int id, User serie)
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
    }
}