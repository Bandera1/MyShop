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
    public class ProducerRepository : IProducer
    {
        private readonly EFDbContext _context;

        public ProducerRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public List<Producer> GetProducers(List<Filter<Producer>> Filters, Func<Producer, object> key,int count, int startIndex = 0)
        {
            var res = _context.Producers.ToList();

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
