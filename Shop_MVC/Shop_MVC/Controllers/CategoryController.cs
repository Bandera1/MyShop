using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Models;

namespace Shop_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly ICategoryType _categoryType;

        public CategoryController(ICategory category,ICategoryType categoryType)
        {
            _category = category;
            _categoryType = categoryType;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CategoryViewModel();
            viewModel.Types = _categoryType.GetCategories(null, x => x.Id, -1);
            viewModel.AllCategories = _category.GetCategories(null, x => x.Id, -1);

            return View(viewModel);
        }
    }
}