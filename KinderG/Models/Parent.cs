using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Parent :User
    {
        public DateTime dateReg { get; set; }
        public string adresse { get; set; }
        public string etatCivil { get; set; }
        public virtual ICollection<Parent> parentlist { get; set; }
        //public Parent proprietaire { get; set; }
        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }

    }
}
