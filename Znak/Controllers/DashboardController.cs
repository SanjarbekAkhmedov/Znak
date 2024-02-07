using Microsoft.AspNetCore.Mvc;
using Znak.Services;

namespace Znak.Controllers
{
    public class DashboardController : ControllerBase
    {
        public DashboardController(IAuthenticationUser authentication) : base(authentication)
        {
        }

        public IActionResult Index() => View();
    }
}
