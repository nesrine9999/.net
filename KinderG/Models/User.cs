using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class User
    {
        public long idU { get; set; }
        [Display(Name = "First name")]
        public string firstName { get; set; }
        [Display(Name = "Last name")]
        public string lastName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
        public string username { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public User autre { get; set; }
        public User proprietaire { get; set; }
        public Invitation send { get; set; }
        public Invitation receive { get; set; }
        // public User<int, autre> autre { get; set; }
        //.public User[] autre { get; set; }
        public virtual Message msg { get; set;}
    }
}

