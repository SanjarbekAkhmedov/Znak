using Microsoft.AspNetCore.Mvc;
using Znak.HelperMethods;
using Znak.Model;
using Znak.Model.Entities;
using Znak.Model.MockData;
using Znak.Services;
using Znak.ViewModels.Product;
using Znak.ViewModels.User;

namespace Znak.Controllers
{
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly EFContext context;
        private readonly IRepository<User> userRepository;

        public UserController(IAuthenticationUser authentication, EFContext context, IRepository<User> userRepository) : base(authentication)
        {
            if (!context.Users.Any())
            {
                context.CreateMockData();
                context.SaveChanges();
            }

            this.context = context;
            this.userRepository = userRepository;
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
        public async Task<IActionResult> Registration(RegistrationViewModel viewModel)
        {
            try
            {
                await userRepository.CreateAsync(new User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Address = viewModel.Address,
                    Login = viewModel.Login,
                    Password = viewModel.Password,
                    Avatar = viewModel.Avatar.ConvertIFormFileToByteArray(),
                    UserRole = UserRole.Admin
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

        [HttpGet(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            var viewModel = new UserViewModel()
            {
                Users = await userRepository.GetAllAsync()
            };
            return View(viewModel);
        }

        [HttpGet(nameof(ViewUser))]
        public async Task<IActionResult> ViewUser(Guid id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                var viewModel = new UserViewViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.Phone,
                    Login = user.Login,
                    Password = user.Password,
                    Avatar = user.Avatar
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
