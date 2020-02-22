using Shop_MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Models
{
    public class CategoryViewModel
    {
        public List<CategoryType> Types { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}
