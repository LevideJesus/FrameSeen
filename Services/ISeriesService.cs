using FrameSeen.Dtos;
using FrameSeen.Models;
namespace FrameSeen.Services
{
    public interface ISerieService
    {
        Task<TvMazeShowDto?> GetSeriesFromTvMazeAsync(int tvMazeId);
        IEnumerable<SerieResponse> GetAllSeries();

        SerieResponse? GetSeriesById(int id);

        SerieResponse AddSeries(SerieRequest series);

        Task<List<TvMazeShowDto>?> SearchSeriesAsync(string query);

        void UpdateSeries(int id, Series series);

        void DeleteSeries(int id);
    }
}
