using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop_MVC.Controllers.Catalogs
{
    public class MensController : Controller
    {
        [Route("Mens/Catalog")]
        [Route("Mens/Catalog/{filters?}")]
        public IActionResult Catalog(string filters)
        {
            return View("~/Views/Catalogs/Mens/Catalog.cshtml");
        }
    }
}