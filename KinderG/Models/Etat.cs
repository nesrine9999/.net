using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public enum Etat
    {
        [Display(Name = "ACCEPET")]
        ACCEPET,
        [Display(Name = "REFUSE")]
        REFUSE,
        [Display(Name = "WAITING")]
        WAITING
    }

}
