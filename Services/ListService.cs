using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FrameSeen.Services
{
    public class ListService : IListService
    {
       private readonly AppDbContext context;

       public ListService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public IEnumerable<ListResponse> GetAllLists(int userId)
        {
            var lists = context.Lists.
                Where(l => l.UserId == userId).ToList();

            var response = lists.Select(l => new ListResponse
            {
                Id = l.Id,
                UserId = l.UserId,
                Name = l.Name,
                CreatedAt = l.CreatedAt

            });
            

            return response;
        }

        public ListResponse? GetListById(int id)
        {
            var list = context.Lists.Find(id);

            var response = list == null ? null : new ListResponse
            {
                Id = list.Id,
                UserId = list.UserId,
                Name = list.Name,
                CreatedAt = list.CreatedAt
            };

            return response;
        }

        public ListResponse AddList(ListRequest listRequest)
        {
            var lists = new List
            {
                Id = 0,
                Name = listRequest.Name,
                UserId = listRequest.UserId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var newList = context.Lists.Add(lists);
            context.SaveChanges();

            var response = new ListResponse
            {
                Id = newList.Entity.Id,
                UserId = newList.Entity.UserId,
                Name = newList.Entity.Name,
                CreatedAt = newList.Entity.CreatedAt
            };

            return response;
        }

        public void DeleteList(int id)
        {
            var list = context.Lists.Find(id);

            if(list != null)
            {
                context.Lists.Remove(list);
                context.SaveChanges();
            }
        }

        public ListResponse? UpdateList(int id, ListRequest request)
        {
            var existingList = context.Lists.Find(id);

            if(existingList == null)
            {
                return null;
            }

            existingList.Name = request.Name;
            existingList.UserId = request.UserId;
            context.SaveChanges();

            return new ListResponse
            {
                Name = existingList.Name,
                UserId = existingList.UserId,
                CreatedAt = existingList.CreatedAt
            };
        }
    }
}