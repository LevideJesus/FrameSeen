using System.Security.Claims;
using FrameSeen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace FrameSeen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService service;

        public ListController(IListService listService)
        {
            service = listService;
        }

        [Authorize]
        [HttpGet]

        public IActionResult GetAllLists()
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(nameIdentifier))
            {
                return Unauthorized();
            }

            if(!int.TryParse(nameIdentifier, out int userId))
            {
                return BadRequest();
            }

            var lists = service.GetAllLists(userId);

            return Ok(lists);
        }
    }
}