using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinderG.Models
{
    public class Claim
    {
        public long id { get; set; }
        public string contentC { get; set; }
        public DateTime dateC { get; set; }
        public List<String> stateC { get; set; }
        public string subjectC{ get; set; }
        public List<String> type { get; set; }
    }
    public enum Type
    {
        Tecnical, Others
    }
    public enum StateC
    {
        treaty, untreated
    }
}
