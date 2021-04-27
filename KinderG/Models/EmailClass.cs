using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class EmailClass
    {
        public string to { get; set; }
        public string  From { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}