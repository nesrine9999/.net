using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Product
    {
        public int id { get; set; }
        public string nomProd { get; set; }
        public int stock { get; set; }
        public int prix { get; set; }
        public string image { get; set; }

    }
}