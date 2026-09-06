using System.Security.Claims;
using FrameSeen.Dtos;
using FrameSeen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    [Route("api/lists/{listId}/items")]
    [ApiController]
    public class ListItemController : ControllerBase
    {
      
        private readonly IListItemService service;

        public ListItemController(IListItemService listItemService)
        {
            service = listItemService;
        }

        [Authorize]
        [HttpGet]

        public IActionResult GetAllListItems(int listId)
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

            var itemsList = service.GetAllTheListItems(listId, userId);
            
            return Ok(itemsList);
        }

        [Authorize]
        [HttpPost]

        public IActionResult AddItem(int listId, [FromBody] ListItemRequest request)
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

            

            ListItemResponse response = service.AddItem(request.SeriesId, listId, userId);

            return Ok(response);
        }


        [Authorize]
        [HttpDelete("{seriesId}")]

        public IActionResult DeleteItem(int listId, int seriesId)
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

            service.RemoveItem(listId, seriesId, userId);

            return NoContent();
        }
        
    }
}