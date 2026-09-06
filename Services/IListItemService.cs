using FrameSeen.Dtos;
namespace FrameSeen.Services
{
    public interface IListItemService
    {
        IEnumerable<ListItemResponse> GetAllTheListItems(int listId, int userId);
        ListItemResponse AddItem(int listId, int seriesId, int userId);

        void RemoveItem( int listId, int seriesId, int userId);
    }
}