using Znak.Model;
using Znak.Model.Entities;
using Znak.Services;

namespace Znak.Repositories
{
    public class ZnakSystemRepository : Repository<ZnakSystem>
    {
        public ZnakSystemRepository(EFContext context) : base(context)
        {
        }
    }
}
