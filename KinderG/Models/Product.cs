using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Product
    {
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; }
        // foreign Key properties
       // public int? CategoryId { get; set; }
        //public virtual Category MyCategory { get; set; }
        //public virtual ICollection<Provider> Providers { get; set; }
    }
}