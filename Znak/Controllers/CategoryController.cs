using Microsoft.AspNetCore.Mvc;
using Znak.Model.Entities;
using Znak.Services;
using Znak.ViewModels.Category;

namespace Znak.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<ProductCategory> _categoryRepository;

        public CategoryController(IAuthenticationUser authentication, IRepository<ProductCategory> categoryRepository) : base(authentication)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryViewModel = new CategoryViewModel
            {
                ProductCategories = categories.OrderBy(s => s.Name).ToList()
            };
            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            await _categoryRepository.CreateAsync(viewModel.ProductCategory);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            await _categoryRepository.UpdateAsync(viewModel.ProductCategory.Id, viewModel.ProductCategory);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel viewModel)
        {
            await _categoryRepository.DeleteAsync(viewModel.ProductCategory.Id);
            return RedirectToAction("Index");
        }
    }

}
