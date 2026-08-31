using System.Security.Cryptography;
using System.Text;
using BC = BCrypt.Net.BCrypt;
using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;


namespace FrameSeen.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;


        public UserService(AppDbContext appDbContext)
        {
            context = appDbContext;
            
        }

        public User? ValidateUser(string email, string password)
        {
            
            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if(user == null) return null;

            if(!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }
            else
            {
                return user;
            }
            
        }
        public UserResponse AddUsers(UserRequest userRequest)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
            
            var users = new User
            {
                Id = 0,
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = passwordHash,
                CreatedAt = userRequest.CreatedAt
                
                
            };
            
            var newUser = context.Users.Add(users);
            context.SaveChanges();
            
            var response = new UserResponse
            {
                Id = newUser.Entity.Id,
                Name = newUser.Entity.Name,
                Email = newUser.Entity.Email,
                CreatedAt = newUser.Entity.CreatedAt
                
            };

            return response;
        }

        public void DeleteUsers(int id)
        {
            var user = context.Users.Find(id);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            var users = context.Users.ToList();

            var response = users.Select(s => new UserResponse{
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                CreatedAt = s.CreatedAt
                
            });
            return response;
        }

        public UserResponse? GetUsersById(int id)
        {
            var user = context.Users.Find(id);

            var response = user == null ? null : new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt
                
            };
            return response;
        }

        public void UpdateUsers(int id, User users)
        {
            var existingUser = context.Users.Find(id);

            if(existingUser != null)
            {
                existingUser.Name = users.Name;
                existingUser.Email = users.Email;
                existingUser.Password = users.Password;
                existingUser.CreatedAt = users.CreatedAt;
                context.SaveChanges();
            }
        }
    }
}