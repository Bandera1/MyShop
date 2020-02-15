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
    public class CategoryRepository : ICategory
    {
        private readonly EFDbContext _context;

        public CategoryRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetCategories(List<Filter<Category>> Filters, Func<Category, object> key,int count, int startIndex = 0)
        {
            var res = _context.Categories.ToList();
            
            if(count == null  || count <= 0)
            {
                count = res.Count - startIndex;
            }

            if (Filters.Count != 0)
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
