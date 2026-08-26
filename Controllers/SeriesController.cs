using FrameSeen.Dtos;
using FrameSeen.Models;
using FrameSeen.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SeriesController : ControllerBase
    {

        private readonly ISerieService service;
        public SeriesController(ISerieService serieService)
        {
            service = serieService;
        }

        [HttpGet()]
        public IActionResult GetSeries()
        {

            return Ok(service.GetAllSeries());
        }

        [HttpGet ("{id}")]
  
        public IActionResult GetSeriesById(int id)
        {
            var response = service.GetSeriesById(id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("tvmaze/{tvMazeId:int}")]
        public async Task<IActionResult> GetSeriesFromTvMaze(int tvMazeId)
        {
            var response = await service.GetSeriesFromTvMazeAsync(tvMazeId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]

        public IActionResult CreateSerie(SerieRequest serie)
        {
            var createdSerie = service.AddSeries(serie);
            return CreatedAtAction(nameof(GetSeriesById), new {id = createdSerie.Id}, createdSerie);
        }


        [HttpPut("{id}")]
        

        public IActionResult UpdateSerie(int id, Series serie)
        {
            try
            {
                service.UpdateSeries(id, serie);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
            

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSerie(int id)
        {
            try
            {
                service.DeleteSeries(id);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }    
}
