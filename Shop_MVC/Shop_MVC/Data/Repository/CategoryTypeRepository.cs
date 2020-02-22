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
    public class CategoryTypeRepository : ICategoryType
    {
        private readonly EFDbContext _context;

        public CategoryTypeRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void AddCategoryType(CategoryType category)
        {
            throw new NotImplementedException();
        }

        public List<CategoryType> GetCategories(List<Filter<CategoryType>> Filters, Func<CategoryType, object> key, int count, int startIndex = 0)
        {
            var res = _context.CategoryTypes.ToList();

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
