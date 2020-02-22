using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface ICategoryType
    {
        List<CategoryType> GetCategories(List<Filter<CategoryType>> Filters, Func<CategoryType, object> key, int count, int startIndex = 0);

        void AddCategoryType(CategoryType category);
    }
}
