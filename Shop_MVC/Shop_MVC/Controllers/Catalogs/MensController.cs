using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop_MVC.Controllers.Catalogs
{
    public class MensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}