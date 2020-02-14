using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.Data.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Photo { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int GenderId { get; set; }
        public DateTime DateOfAdded { get; set; }
        public bool IsExclusive { get; set; }
        public int ProducerId { get; set; }
        public string AdditionalInfo { get; set; }


        public virtual Category Category { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
