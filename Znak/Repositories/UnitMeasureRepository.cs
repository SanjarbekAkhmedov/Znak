using Znak.Model;
using Znak.Model.Entities;
using Znak.Services;

namespace Znak.Repositories
{
    public class UnitMeasureRepository : Repository<UnitMeasure>
    {
        public UnitMeasureRepository(EFContext context) : base(context)
        {
        }
    }
}
