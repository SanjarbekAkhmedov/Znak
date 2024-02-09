using Znak.Model.Entities;

namespace Znak.ViewModels.Product
{
    public class ProductViewViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public Guid UnitMeasureId { get; set; }

        public UnitMeasure UnitMeasure { get; set; }

        public byte[] Image { get; set; }
    }
}
