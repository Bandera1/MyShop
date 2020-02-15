using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface IProductRating
    {
        List<ProductRating> GetProductRatings(List<Filter<ProductRating>> Filters, Func<ProductRating, object> key,int count, int startIndex = 0);

        void AddProductRating(ProductRating productRating);
    }
}
