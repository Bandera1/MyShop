

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
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
            

            //OrderKey = (x => x.ID);
            //Filters.Add(new Filter<Books>
            //{
            //    Name = "Themes." + nameTheme,
            //    Expression = (x => x.Themes.NameTheme == nameTheme)
            //});


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

    }
}
