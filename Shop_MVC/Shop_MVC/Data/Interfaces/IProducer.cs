using Shop_MVC.Data.Models;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface IProducer
    {
        List<Producer> GetProducers(List<Filter<Producer>> Filters, Func<Producer, object> key, int count, int startIndex = 0);

        void AddProducer(Producer producer);
    }
}
