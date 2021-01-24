using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthService.DataContract
{
    [DataContract (Name ="Country")]
    public class country
    {

        [DataMember(Name = "id")]
        public int CountryID { get; set; }
        [DataMember(Name = "countryName")]
        public string CountryName { get; set; }
        [DataMember(Name = "countryCode")]
        public string CountryCode { get; set; }
        
    }
}