using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Models
{
    public class Category : BaseEntity
    {
        public int ParentId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual CategoryType Type { get; set; }
    }
}
