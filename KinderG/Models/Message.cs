using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public partial class Message
    {
     
        public long idmessage { get; set; }
       [Display(Name ="OBJECT")]
        [Required]
        public string objectM { get; set; }
        [Display(Name ="CONTENT")]
        [Description("Demonstrates DisplayNameAttribute.")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string contentM { get; set; }
        [Display(Name = "Date Send")]
        public DateTime dateSend { get; set; }
        [Display(Name = "Seen")]
        public Boolean msgLu { get; set; }
        
        public string fr { get; set; }
       
        public string picture { get; set; }

        public int UserID { get; set; }

        public virtual User users { get; set; }
        public  User user { get; set; }




    }
        
    }
