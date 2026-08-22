using FrameSeen.Dtos;
using FrameSeen.Models;
namespace FrameSeen.Services
{
    public interface ISerieService
    {
        IEnumerable<SerieResponse> GetAllSeries();

        SerieResponse? GetSeriesById(int id);

        SerieResponse AddSeries(SerieRequest series);

        void UpdateSeries(int id, Series series);

        void DeleteSeries(int id);
    }
}
