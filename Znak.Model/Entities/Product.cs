namespace Znak.Model.Entities
{
    public class Product : Order
    {
        public Guid UnitMeasureId { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Guid ProductCategoryId { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
