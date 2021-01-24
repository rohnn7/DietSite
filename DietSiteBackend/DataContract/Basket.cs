using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.DataContract
{
    [DataContract (Name ="Basket")]
    public class Basket
    {
        [DataMember(Name ="DietID")]
        public int DietID { get; set; }
        [DataMember(Name ="Dateofselection")]
        public DateTime Dateofselection { get; set; }
        [DataMember(Name ="Didvalue")]
        public int Didvalue { get; set; }
        [DataMember(Name ="Grossvalue")]
        public int Grossvalue { get; set; }
        [DataMember(Name ="Taxvalue")]
        public int Taxvalue { get; set; }
       // [DataMember(Name ="Active")]
        //public int Active { get; set; }
        [DataMember (Name ="UserID")]
        public int UserID { get; set; }
        [DataMember(Name ="Summary")]
        public string Summary { get; set; }
        [DataMember(Name="DName")]
        public string DName { get; set; }
        [DataMember(Name ="TryPeriod")]
        public string TryPeriod { get; set; }
        [DataMember(Name = "DietPrice")]
        public string DietPrice { get; set; }
        [DataMember(Name = "Type")]
        public int Type { get; set; }

    }
}