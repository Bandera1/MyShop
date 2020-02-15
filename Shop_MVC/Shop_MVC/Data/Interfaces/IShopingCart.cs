using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface IShopingCart
    {
        List<ShopingCart> GetShopingCarts(List<Filter<ShopingCart>> Filters, Func<ShopingCart, object> key,int count,int startIndex = 0);

        void AddShopingCart(ShopingCart shopingCart);
    }
}
