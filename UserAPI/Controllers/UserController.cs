using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpPost]
        public dynamic CreateUser (User user)
        {
            return new
            {
                status = "OK",
                message = "User created!",
                data = user
            };
        }

        [HttpPost]
        public dynamic Login(User user)
        {
            return new
            {
                status = "OK",
                message = "User created!",
                data = user
            };
        }
    }
}
