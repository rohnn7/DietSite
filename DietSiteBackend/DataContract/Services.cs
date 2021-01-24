using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
namespace HealthService.DataContract
{
    [DataContract(Name ="Services")]
    public class Services
    {
        [DataMember(Name ="SercatID")]
        public int SercatID { get; set; }
        [DataMember(Name ="CategoryName")]
        public string CategoryName { get; set; }
        [DataMember(Name = "Userid")]
        public int UserID { get; set; }
    }
}