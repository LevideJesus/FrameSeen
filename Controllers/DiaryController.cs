using System.Security.Claims;
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

    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService service;


        public DiaryController(IDiaryService diaryService)
        {
            service = diaryService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllDiaries()
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

            var diaries = service.GetAllDiaries(userId);
            return Ok(diaries);
        }

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetDiaryById(int id)
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(nameIdentifier))
            {
                return Unauthorized();
            }

            if (!int.TryParse(nameIdentifier, out int userId))
            {
                return BadRequest();
            }

            var entry = service.GetDiaryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            if (entry.UserId != userId)
            {
                return NotFound();
            }

          
            return Ok(entry);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddDiary(DiaryRequest request)
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

            DiaryResponse response = service.AddDiary(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize]

        public IActionResult UpdateDiary(int id, DiaryRequest request)
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(nameIdentifier))
            {
                return Unauthorized();
            }

            if (!int.TryParse(nameIdentifier, out int userId))
            {
                return BadRequest();
            }

            var entry = service.GetDiaryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            if (entry.UserId != userId)
            {
                return NotFound();
            }

            var response = service.UpdateDiary(id, request);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]

        public IActionResult DeleteDiary(int id)
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(nameIdentifier))
            {
                return Unauthorized();
            }

            if (!int.TryParse(nameIdentifier, out int userId))
            {
                return BadRequest();
            }

            var entry = service.GetDiaryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            if (entry.UserId != userId)
            {
                return NotFound();
            }

            service.DeleteDiary(id);
            return NoContent();
        }
    }
}