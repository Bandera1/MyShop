using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using Shop_MVC.Models;
using Shop_MVC.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Components
{
    public class Navbar : ViewComponent
    {
        private readonly ICategory _category;
        private readonly IProducer _producer;
        private readonly ICategoryType _categoryType;
        private readonly IShopingCart _shopingCart;

        public Navbar(ICategory category, IProducer producer, ICategoryType categoryType, IShopingCart shopingCart)
        {
            _category = category;
            _producer = producer;
            _categoryType = categoryType;
            _shopingCart = shopingCart;
        }


        public IViewComponentResult Invoke()
        {
            HomePageViewModel viewModel = new HomePageViewModel();

            viewModel.Types = _categoryType.GetCategories(null, x => x.Id, -1);
            viewModel.Producers = _producer.GetProducers(null, x => x.Id, -1);
            viewModel.AllCategories = _category.GetCategories(null, x => x.Id, -1);
            viewModel.ShopCartCount = 1;
            viewModel.IsUserLogin = (HttpContext.Session.GetString("UserInfo") != null) ? true : false;

            //viewModel.IsUserLogin = true;
            //if(HttpContext.Session.GetString("UserInfo") == null)
            //{
            //    viewModel.IsUserLogin = false;
            //}

            List<Filter<ShopingCart>> filters = new List<Filter<ShopingCart>>();
            filters.Add(new Filter<ShopingCart>
            {
                Name = "ShopCartCount",
                Expression = (x => x.UserId == JsonConvert.DeserializeObject<UserInfo>(HttpContext.Session.GetString("UserInfo")).UserId)
            });
            viewModel.ShopCartCount = (viewModel.IsUserLogin == false) ? 0 : _shopingCart.GetShopingCarts(filters, x => x.Id, -1).Count;


            return View(viewModel);
        }
    }
}
