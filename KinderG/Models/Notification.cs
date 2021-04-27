using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Notification
    {
        public long id { get; set; }
        public string titleN { get; set; }
        public string contentN { get; set; }
        public Boolean msgLu { get; set; }
        public virtual User users { get; set; }
        public User user { get; set; }
    }
}