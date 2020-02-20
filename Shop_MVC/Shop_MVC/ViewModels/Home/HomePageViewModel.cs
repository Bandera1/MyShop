using Shop_MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<CategoryType> Types { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Producer> Producers { get; set; }
        public int ShopCartCount { get; set; }
        public bool IsUserLogin { get; set; }
    }
}
