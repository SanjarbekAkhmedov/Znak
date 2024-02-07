using Microsoft.AspNetCore.Mvc;
using Znak.Model.Entities;
using Znak.Repositories;
using Znak.Services;
using Znak.ViewModels;

namespace Znak.Controllers
{
    public class MenuController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly ProductCategoryRepository _productCategoryRepository;
        private readonly UnitMeasureRepository _unitMeasureRepository;

        public MenuController(IAuthenticationUser authentication, ProductRepository productRepository, ProductCategoryRepository productCategoryRepository, UnitMeasureRepository unitMeasureRepository) : base(authentication)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitMeasureRepository = unitMeasureRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var menuViewModel = new MenuViewModel
            {
                TList = products.OrderBy(s => s.Name).ToList()
            };
            return View(menuViewModel);
        }

        public async Task<IActionResult> AddProduct()
        {
            var product = new Product();
            var productCategories = await _productCategoryRepository.GetAllAsync();
            var unitMeasures = await _unitMeasureRepository.GetAllAsync();
            ViewBag.ProductCategories = productCategories;
            ViewBag.UnitMeasures = unitMeasures;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> GetProduct(Product product)
        {
            product = await _productRepository.GetByIdAsync(product.Id);
            product.ProductCategory = await _productCategoryRepository.GetByIdAsync(product.ProductCategoryId);
            product.UnitMeasure = await _unitMeasureRepository.GetByIdAsync(product.UnitMeasureId);
            var productCategories = await _productCategoryRepository.GetAllAsync();
            var unitMeasures = await _unitMeasureRepository.GetAllAsync();
            ViewBag.ProductCategories = productCategories;
            ViewBag.UnitMeasures = unitMeasures;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _productRepository.UpdateAsync(product.Id, product);
            return RedirectToAction("Index", "Menu");
        }

        [HttpPost]
        public async Task<IActionResult> ViewProduct(Product product)
        {
            product = await _productRepository.GetByIdAsync(product.Id);
            product.ProductCategory = await _productCategoryRepository.GetByIdAsync(product.ProductCategoryId);
            product.UnitMeasure = await _unitMeasureRepository.GetByIdAsync(product.UnitMeasureId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            await _productRepository.DeleteAsync(product.Id);
            return RedirectToAction("Index", "Menu");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                await _productRepository.CreateAsync(product);
            }
            catch (Exception)
            {
                // Handle exception
            }
            return RedirectToAction("Index", "Menu");
        }
    }
}
