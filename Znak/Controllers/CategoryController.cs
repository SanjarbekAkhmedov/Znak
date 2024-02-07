﻿using Microsoft.AspNetCore.Mvc;
using Znak.Repositories;
using Znak.Services;
using Znak.ViewModels;

namespace Znak.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ProductCategoryRepository _categoryRepository;

        public CategoryController(AuthenticationUser authentication, ProductCategoryRepository categoryRepository) : base(authentication)
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
