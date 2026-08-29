using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;


namespace FrameSeen.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        private readonly IHttpClientFactory httpClientFactory;

        public UserService(AppDbContext appDbContext, IHttpClientFactory httpClientFactory)
        {
            context = appDbContext;
            this.httpClientFactory = httpClientFactory;
        }
        public UserResponse AddUsers(UserRequest request)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User? GetUsersById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsers(int id, User users)
        {
            throw new NotImplementedException();
        }

        
    }
}