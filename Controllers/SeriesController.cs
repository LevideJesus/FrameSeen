using FrameSeen.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeriesController : ControllerBase
    {
        static List<Series> series = new List<Series>
        {
            new Series {Id = 1, 
                Name = "Vikings", 
                Overview = "The show follows the legendary Norse hero Ragnar Lothbrok.", 
                PosterPath = "https://image.tmdb.org/t/p/original/oktTNFM8PzdseiK1X0E0XhB6LvP.jpg", 
                NumberOfSeasons = 9, 
                NumberOfEpisodes = 200, 
                EpisodeRunTime =  22, 
                Status = "Ended", 
                FirstAirDate = new DateTime(2016, 7, 15)}
            };
    
        
        [HttpGet]

        
        public IActionResult GetSeries()
        {

            return Ok(series);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSeriesById(int id)
        {
            var response = series.FirstOrDefault(s => s.Id == id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        
    }    
}
