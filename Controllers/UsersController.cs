using FrameSeen.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrameSeen.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
        }
    }
}