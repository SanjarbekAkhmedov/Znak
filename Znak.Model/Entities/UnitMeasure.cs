using System.Collections.Generic;

namespace Znak.Model.Entities
{
    public class UnitMeasure : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
