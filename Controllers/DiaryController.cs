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
            return Ok(service.GetAllDiaries());
        }

        [HttpGet("{id}")]

        public IActionResult GetDiaryById(int id)
        {
            var response = service.GetDiaryById(id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddDiary(DiaryRequest request)
        {
            DiaryResponse response = service.AddDiary(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize]

        public IActionResult UpdateDiary(int id, Diary diary)
        {
            try
            {
                service.UpdateDiary(id, diary);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]

        public IActionResult DeleteDiary(int id)
        {
            try
            {
                service.DeleteDiary(id);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}