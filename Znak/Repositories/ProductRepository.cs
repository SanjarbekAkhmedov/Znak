using Znak.Model;
using Znak.Model.Entities;
using Znak.Services;

namespace Znak.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(EFContext context) : base(context)
        {
        }
    }
}
