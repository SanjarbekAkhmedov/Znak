using Microsoft.AspNetCore.Mvc;
using Znak.Model;
using Znak.Model.MockData;
using Znak.Services;

namespace Znak.Controllers
{
    [Route("")]
    public class LoginController : ControllerBase
    {
        public LoginController(IAuthenticationUser authentication, EFContext context) : base(authentication)
        {
            if (!context.Users.Any())
            {
                context.CreateMockData();
                context.SaveChanges();
            }
        }

        [Route("")]
        public ViewResult Login()
        {
            return View();
        }
    }
}
