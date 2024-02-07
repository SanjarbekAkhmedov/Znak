using Microsoft.AspNetCore.Mvc;
using Znak.Services;

namespace Znak.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected IAuthenticationUser Authentication { get; set; }
        public ControllerBase(IAuthenticationUser authentication)
        {
            Authentication = authentication;
        }
    }
}
