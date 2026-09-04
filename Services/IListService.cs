using FrameSeen.Dtos;
using FrameSeen.Models;
namespace FrameSeen.Services
{
    public interface IListService
    {
        IEnumerable<ListResponse> GetAllLists(int userId);

        ListResponse? GetListById(int id);

        ListResponse AddList(ListRequest request);
        ListResponse? UpdateList(int id, ListRequest request);
        void DeleteList(int id);
    }
}