using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;

namespace FrameSeen.Services
{
    public class ListItemService : IListItemService
    {
        private readonly AppDbContext context;

        public ListItemService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }


        public IEnumerable<ListItemResponse> GetAllTheListItems(int listId, int userId)
        {
            var itemsList = context.Lists.Find(listId);

            if (itemsList == null || itemsList.UserId != userId)
            {
                return Enumerable.Empty<ListItemResponse>();
            }

            var items = context.ListItem.Where(i => i.ListId == listId).ToList();

            return items.Select(i => new ListItemResponse
            {
                Id = i.Id,
                ListId = i.ListId,
                SeriesId = i.SeriesId
            });
        }

        public ListItemResponse AddItem(int listId, int seriesId, int userId)
        {
            var list = context.Lists.Find(listId);
            if (list == null || list.UserId != userId)
            {
                return null!; 
            }

            var item = new ListItem
            {
                Id = 0,
                ListId = listId,
                SeriesId = seriesId
            };

            var added = context.ListItem.Add(item);
            context.SaveChanges();

            return new ListItemResponse
            {
                Id = added.Entity.Id,
                ListId = added.Entity.ListId,
                SeriesId = added.Entity.SeriesId
            };
        }

        public void RemoveItem(int listId, int seriesId, int userId)
        {
            var list = context.Lists.Find(listId);
            if (list == null || list.UserId != userId)
            {
                return;
            }

            var item = context.ListItem
                .FirstOrDefault(i => i.ListId == listId && i.SeriesId == seriesId);

            if (item != null)
            {
                context.ListItem.Remove(item);
                context.SaveChanges();
            }
        }
    }
}