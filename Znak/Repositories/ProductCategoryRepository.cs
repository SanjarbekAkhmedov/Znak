using Znak.Model;
using Znak.Model.Entities;
using Znak.Services;

namespace Znak.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(EFContext context) : base(context)
        {
        }
    }
}
