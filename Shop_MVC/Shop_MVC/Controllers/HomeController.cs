

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Data.Models;
using Shop_MVC.Models;
using Shop_MVC.ViewModels.Home;

namespace Shop_MVC.Controllers
{
    public class HomeController : Controller
    {
        //[Route("Home/Products")]
        //[Route("Home/Products/{page}")]
        //[Route("Home/Products/{page}/{category}")]
        //[Route("Home/Products/{page}/{category}/{producer}")]
        //[Route("Home/Products/{page}/{category}/{producer}/{size}")]
        //[Route("Home/Products/{page}/{category}/{producer}/{size}/{colors}")]
        //[Route("Home/Products/{page}/{category}/{producer}/{size}/{colors}/{gender}")]
        //[Route("Home/Products/{page}/{category}/{producer}/{size}/{colors}/{gender}/{rating}")]
        //[HttpPost]
        //public IActionResult Products(string page, string category, string producer, string size, string colors, string gender, string rating)
        //{
        //    return View();
        //}








        public IActionResult Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel();

            viewModel.Types = new List<CategoryType>();
            viewModel.Producers = new List<Producer>();
            viewModel.AllCategories = new List<Category>();

            viewModel.Types.Add(new CategoryType() { Id=1, Name = "Men`s" });
            viewModel.Types.Add(new CategoryType() { Id=2, Name = "Women`s" });
            viewModel.Types.Add(new CategoryType() { Id=3, Name = "Kid`s" });

            viewModel.Producers.Add(new Producer() { Name = "Adidas" });
            viewModel.Producers.Add(new Producer() { Name = "Nike" });
            viewModel.Producers.Add(new Producer() { Name = "Reebok" });

            viewModel.AllCategories.Add(new Category
            {
                Id = 1,
                Name = "Shoes",
                TypeId = 1                
            });
            viewModel.AllCategories.Add(new Category
            {
                Id = 2,
                Name = "Clothing",
                TypeId = 1
            });
            viewModel.AllCategories.Add(new Category
            {
                Id = 3,
                Name = "Accesories",
                TypeId = 1
            });


            viewModel.AllCategories.Add(new Category
            {
                Name = "Running",
                ParentId = 1,
                TypeId = 1
            });
            viewModel.AllCategories.Add(new Category
            {
                Name = "Pants",
                ParentId = 2,
                TypeId = 1
            });
            viewModel.AllCategories.Add(new Category
            {
                Name = "Watchs",
                ParentId = 3,
                TypeId = 1
            });






            viewModel.IsUserLogin = true;
            viewModel.ShopCartCount = 3;


            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
