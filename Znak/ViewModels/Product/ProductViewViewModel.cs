using Znak.Model.Entities;

namespace Znak.ViewModels.Product
{
    using Znak.Model.Entities;

    public class ProductViewViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public UnitMeasure UnitMeasure { get; set; }

        public byte[] Image { get; set; }
    }
}
