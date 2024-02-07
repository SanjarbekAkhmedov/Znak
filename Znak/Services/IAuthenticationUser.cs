using Znak.Model.Entities;

namespace Znak.Services
{
    public interface IAuthenticationUser
    {
        bool IsLoggedIn { get; }
        Task<User> SignIn(string login, string pass);
        void SignUp();
    }
}
