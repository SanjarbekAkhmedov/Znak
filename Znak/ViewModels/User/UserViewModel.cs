namespace Znak.ViewModels.User
{
    using Znak.Model.Entities;

    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
