namespace Znak.Model.Entities
{
    public class UnitMeasure : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
