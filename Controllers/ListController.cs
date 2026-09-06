using System.Security.Claims;
using FrameSeen.Dtos;
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

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetListById(int id)
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

            var entry = service.GetListById(id);

            if(entry == null)
            {
                return NotFound();
            }

            if(entry.UserId != userId)
            {
                return NotFound();
            }


            return Ok(entry);
        }

        [HttpPost]
        [Authorize]

        public IActionResult AddList(ListRequest request)
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

            request.UserId = userId;

            ListResponse response = service.AddList(request);

            return Ok(response);
        }
    }
}