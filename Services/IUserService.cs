using FrameSeen.Models;
using FrameSeen.Dtos;


namespace FrameSeen.Services
{
    public interface IUserService
    {
        IEnumerable<UserResponse> GetAllUsers();
        UserResponse? GetUsersById(int id);
        UserResponse AddUsers(UserRequest userRequest);
        User? ValidateUser(string email, string password);
        void UpdateUsers(int id, User users);
        void DeleteUsers(int id);
    }
}