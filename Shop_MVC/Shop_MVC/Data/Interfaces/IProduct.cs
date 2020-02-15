using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProducts(List<Filter<Product>> Filters, Func<Product, object> key,int count,int startIndex = 0);

        void AddProduct(Product product);
    }
}
