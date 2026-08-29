using FrameSeen.Models;
using FrameSeen.Data;
using FrameSeen.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace FrameSeen.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();
        Users? GetUsersById(int id);
        Series AddUsers(UserRequest request);
        void UpdateUsers(int id, Users users);
        void DeleteUsers(int id);
    }
}