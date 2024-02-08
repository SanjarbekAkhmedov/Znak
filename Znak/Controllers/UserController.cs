using Microsoft.AspNetCore.Mvc;
using Znak.HelperMethods;
using Znak.Model;
using Znak.Model.MockData;
using Znak.Services;
using Znak.ViewModels;

namespace Znak.Controllers
{
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly EFContext context;

        public UserController(IAuthenticationUser authentication, EFContext context) : base(authentication)
        {
            if (!context.Users.Any())
            {
                context.CreateMockData();
                context.SaveChanges();
            }

            this.context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet(nameof(Registration))]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost(nameof(Registration))]
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            try
            {
                context.Users.Add(new Model.Entities.User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Address = viewModel.Address,
                    Login = viewModel.Login,
                    Password = viewModel.Password,
                    Avatar = viewModel.Avatar.ConvertIFormFileToByteArray(),
                    UserRole = Model.Entities.UserRole.Admin
                });
                context.SaveChanges();
                return RedirectToAction(nameof(RegistrationSuccessful));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet(nameof(RegistrationSuccessful))]
        public IActionResult RegistrationSuccessful()
        {
            return View();
        }
    }
}
