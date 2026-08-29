using FrameSeen.Models;
using FrameSeen.Dtos;


namespace FrameSeen.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUsersById(int id);
        UserResponse AddUsers(UserRequest request);
        void UpdateUsers(int id, User users);
        void DeleteUsers(int id);
    }
}