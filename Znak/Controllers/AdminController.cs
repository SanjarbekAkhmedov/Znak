using Microsoft.AspNetCore.Mvc;
using Znak.Model.Entities;
using Znak.Services;
using Znak.ViewModels;

namespace Znak.Controllers
{
    public class AdminController : ControllerBase
    {
        public AdminController(IAuthenticationUser authentication) : base(authentication)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(LoginViewModel loginViewModel)
        {
            User user = Authentication.SignIn(loginViewModel.Login, loginViewModel.Password).Result;
            return View(user);
        }
    }
}
