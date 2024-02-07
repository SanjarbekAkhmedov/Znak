namespace Znak.Model.Entities
{
    public abstract class Order : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
