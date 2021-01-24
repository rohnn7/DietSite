using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace DietSite
{
    [DataContract(Name ="DeitTable")]
    public class DeitTable
    {
        [DataMember(Name ="DeitID")]
        public int DeitID { get; set; }
        [DataMember(Name ="DeitSummary")]
        public string DeitSummary { get; set; }
        [DataMember(Name ="Princing")]
        public string Princing { get; set; }
        [DataMember (Name ="Tax")]
        public double Tax { get; set; }
        
        [DataMember(Name = "TrialPeriod")]
        public int TrialPeriod { get; set; }
        [DataMember(Name ="Active")]
        public int Active { get; set; }

        [DataMember(Name = "DeittypeID")]
        public int DeittypeID { get; set; }
        [DataMember(Name = "Type")]
        public int Type { get; set; }
        [DataMember(Name = "DietName")]
        public string DietName { get; set; }

    }
}