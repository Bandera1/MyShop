using Shop_MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.ViewModels
{
    public class CatalogViewModel
    {
        public Dictionary<string,bool> Categories { get; set; }
        public Dictionary<string,bool> Producers { get; set; }
        public Dictionary<string,bool> Sizes { get; set; }
        public Dictionary<string, bool> Colors { get; set; }
        public int MaxCost { get; set; }
        public int MinCost { get; set; }
        public string SortKey { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
