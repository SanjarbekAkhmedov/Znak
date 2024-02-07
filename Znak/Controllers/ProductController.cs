using Microsoft.AspNetCore.Mvc;
using Znak.Repositories;
using Znak.Services;
using Znak.ViewModels;

namespace Znak.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(IAuthenticationUser authentication, ProductRepository productRepository) : base(authentication)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var productViewModel = new ProductViewModel
            {
                Products = products.ToList()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            await _productRepository.CreateAsync(viewModel.Product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            await _productRepository.UpdateAsync(viewModel.Product.Id, viewModel.Product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel viewModel)
        {
            await _productRepository.DeleteAsync(viewModel.Product.Id);
            return RedirectToAction("Index");
        }
    }

}
