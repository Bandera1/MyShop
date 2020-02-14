using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Models
{
    public class ProductRating : BaseEntity
    {
        public int ProductId { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }

        public virtual Product Product { get; set; }
    }
}
