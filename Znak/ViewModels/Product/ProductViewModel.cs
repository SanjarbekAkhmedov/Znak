namespace Znak.ViewModels.Product
{
    using Znak.Model.Entities;

    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
