﻿using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface ICategory
    {
        List<Category> GetCategories(List<Filter<Category>> Filters, Func<Category, object> key,int count,int startIndex = 0);

        void AddCategory(Category category);
    }
}
