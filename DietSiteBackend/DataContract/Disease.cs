using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.DataContract

{
    [DataContract (Name ="Disease")]
    public class Disease
    {
        [DataMember (Name ="DiseaseID")]
        public int DieseaseID { get; set; }
        [DataMember(Name ="DiseaseName")]
        public string DiseaseName { get; set; }
        [DataMember(Name = "Userid")]
        public int UserID { get; set; }
    }
}