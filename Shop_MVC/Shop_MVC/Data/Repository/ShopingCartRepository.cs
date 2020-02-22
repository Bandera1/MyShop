using FirstASP.NETapplication.Data.EFContext;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Repository
{
    public class ShopingCartRepository : IShopingCart
    {
        private readonly EFDbContext _context;

        public ShopingCartRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddShopingCart(ShopingCart shopingCart)
        {
            _context.ShopingCarts.Add(shopingCart);
        }

        public List<ShopingCart> GetShopingCarts(List<Filter<ShopingCart>> Filters, Func<ShopingCart, object> key,int count, int startIndex = 0)
        {
            var res = _context.ShopingCarts.ToList();

            if (count == null || count <= 0)
            {
                count = res.Count - startIndex;
            }

            if (Filters != null && Filters.Count != 0)
            {
                res = res.Where(x => Filters.Any(f => f.Expression(x) == true))
                .ToList();
            }

            return res.OrderBy(key)
                .Skip(startIndex)
                .Take(count).ToList();
        }
    }
}
