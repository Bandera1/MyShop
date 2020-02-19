

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Models;

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
            

            return View();
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

        //public void Click()
        //{
        //    System.Diagnostics.Debug.WriteLine("Click");
        //}
    }
}
