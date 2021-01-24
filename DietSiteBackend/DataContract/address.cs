using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HealthService.DataContract
{
    [DataContract(Name = "Address")]
    public class address
    {
        [DataMember(Name = "Userid")]
        public int UserID { get; set; }
        [DataMember (Name ="addressid")]
        public int AddressID { get; set; }
        [DataMember (Name ="add1")]
        public string Add1 { get; set; }
        [DataMember(Name ="add2")]
        public string Add2 { get; set; }
        [DataMember(Name = "id")]
        public int CountryID { get; set; }
        [DataMember(Name = "countryName")]
        public string CountryName { get; set; }
        [DataMember(Name = "countryCode")]
        public string CountryCode { get; set; }
        [DataMember(Name = "stateid")]
        public int Stateid { get; set; }
        [DataMember(Name = "statename")]
        public string Statename { get; set; }

        [DataMember(Name = "Cityid")]
        public int CityID { get; set; }
        [DataMember(Name = "Cityname")]
        public string CityName { get; set; }

    }

}