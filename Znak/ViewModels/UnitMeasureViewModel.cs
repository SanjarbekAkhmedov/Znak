using Znak.Model.Entities;

namespace Znak.ViewModels
{
    public class UnitMeasureViewModel
    {
        public UnitMeasure UnitMeasure { get; set; }
        public UnitMeasureViewModel()
        {
            UnitMeasures = new List<UnitMeasure>();
        }
        public IEnumerable<UnitMeasure> UnitMeasures { get; set; }
        public IEnumerable<UnitMeasure> Add(UnitMeasure unit)
        {
            UnitMeasures.ToList().Add(unit);
            return UnitMeasures;
        }
    }
}
