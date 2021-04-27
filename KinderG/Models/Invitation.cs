using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Invitation
    {
        public long id { get; set; }
        [Display(Name = "State")]
        public Etat etat { get; set; }
        [Display(Name = "SENDER")]
        public string sender { get; set; }
        public User send { get; set; }
        public User receive { get; set; }

    }
}