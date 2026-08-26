using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FrameSeen.Services
{
    public class SeriesService : ISerieService
    { 
        private readonly AppDbContext context;
        private readonly IHttpClientFactory httpClientFactory;
        public SeriesService(AppDbContext appDbContext, IHttpClientFactory httpClientFactory)
        {
            context = appDbContext;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<TvMazeShowDto?> GetSeriesFromTvMazeAsync(int tvMazeId)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.tvmaze.com/");

            var response = await client.GetAsync($"shows/{tvMazeId}");

            if (response.IsSuccessStatusCode)
            {
                var show = await response.Content.ReadFromJsonAsync<TvMazeShowDto>();
                return show;
            }

            return null;
        }

        public async Task<List<TvMazeShowDto>?> SearchSeriesAsync(string query)
        {
            var search = httpClientFactory.CreateClient();
            search.BaseAddress = new Uri($"https://api.tvmaze.com/");

            var response = await search.GetAsync($"search/shows?q={Uri.EscapeDataString(query)}");

            if (response.IsSuccessStatusCode)
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var searchResults = await response.Content.ReadFromJsonAsync<List<TvMazeSearchResultDto>>();
                return searchResults?.Select(r => r.Show).ToList();

                
            }

            return null;
        }
        public SerieResponse AddSeries(SerieRequest seriesRequest)
        {
            var series = new Series
            {
                Id = 0,
                Name = seriesRequest.Name,
                Overview = seriesRequest.Overview,
                PosterPath = seriesRequest.PosterPath,
                NumberOfEpisodes = seriesRequest.NumberOfEpisodes,
                NumberOfSeasons = seriesRequest.NumberOfSeasons,
                EpisodeRunTime = seriesRequest.EpisodeRunTime,
                Status = seriesRequest.Status,
                FirstAirDate = seriesRequest.FirstAirDate
                
            };
            
            var newSerie = context.Series.Add(series);
            context.SaveChanges();
            
            var response = new SerieResponse
            {
                Id = newSerie.Entity.Id,
                Name = newSerie.Entity.Name,
                Overview = newSerie.Entity.Overview,
                PosterPath = newSerie.Entity.PosterPath,
                NumberOfEpisodes = newSerie.Entity.NumberOfEpisodes,
                NumberOfSeasons = newSerie.Entity.NumberOfSeasons,
                EpisodeRunTime = newSerie.Entity.EpisodeRunTime,
                Status = newSerie.Entity.Status,
                FirstAirDate = newSerie.Entity.FirstAirDate
            };

            return response;
        }


        public void DeleteSeries(int id)
        {
            var serie = context.Series.Find(id);
            if(serie != null)
            {
                context.Series.Remove(serie);
                context.SaveChanges();
            }
        }

        public IEnumerable<SerieResponse> GetAllSeries()
        {
            var series = context.Series.ToList();

            var response = series.Select(s => new SerieResponse{
                Id = s.Id,
                Name = s.Name,
                Overview = s.Overview,
                PosterPath = s.PosterPath,
                NumberOfEpisodes = s.NumberOfEpisodes,
                NumberOfSeasons = s.NumberOfSeasons,
                EpisodeRunTime = s.EpisodeRunTime,
                Status = s.Status,
                FirstAirDate = s.FirstAirDate
            });
            return response;
        }

        public SerieResponse? GetSeriesById(int id)
        {
            var serie = context.Series.Find(id);

            var response = serie == null ? null : new SerieResponse
            {
                Id = serie.Id,
                Name = serie.Name,
                Overview = serie.Overview,
                PosterPath = serie.PosterPath,
                NumberOfEpisodes = serie.NumberOfEpisodes,
                NumberOfSeasons = serie.NumberOfSeasons,
                EpisodeRunTime = serie.EpisodeRunTime,
                Status = serie.Status,
                FirstAirDate = serie.FirstAirDate
            };
            return response;
        }

        public void UpdateSeries(int id, Series series)
        {
            var existingSerie = context.Series.Find(id);

            if(existingSerie != null)
            {
                existingSerie.Name = series.Name;
                existingSerie.Overview = series.Overview;
                existingSerie.PosterPath = series.PosterPath;
                existingSerie.NumberOfEpisodes = series.NumberOfEpisodes;
                existingSerie.NumberOfSeasons = series.NumberOfSeasons;
                existingSerie.EpisodeRunTime = series.EpisodeRunTime;
                existingSerie.Status = series.Status;
                existingSerie.FirstAirDate = series.FirstAirDate;
                context.SaveChanges();
            }

            
        }

        
    }
}