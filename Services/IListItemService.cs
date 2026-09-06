using FrameSeen.Dtos;
namespace FrameSeen.Services
{
    public interface IListItemService
    {
        IEnumerable<ListItemResponse> GetAllTheListItems(int listId);
        ListItemResponse AddItem(int listId, int seriesId);

        void DeleteList(int listId, int seriesId);
    }
}