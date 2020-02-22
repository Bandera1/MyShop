using FirstASP.NETapplication.Data.EFContext;
using Shop_MVC.Data.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Interfaces
{
    public interface IUser
    {
        List<DbUser> GetUsers(List<Filter<DbUser>> Filters, Func<DbUser, object> key, int count, int startIndex = 0);     
    }
}
