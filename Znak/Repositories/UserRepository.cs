using Znak.Model;
using Znak.Model.Entities;
using Znak.Services;

namespace Znak.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EFContext context) : base(context)
        {
        }
    }
}
