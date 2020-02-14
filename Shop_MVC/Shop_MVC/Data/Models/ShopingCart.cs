using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Models
{
    public class ShopingCart : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual Product Product { get; set; }
    }
}
