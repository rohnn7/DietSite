using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace HealthService.DataContract
{
    [DataContract(Name = "Param")]
    public class Param
    {
        [DataMember(Name = "CountryDetails")]
        public country CountryDetails { get; set; }
        [DataMember(Name = "StateDetails")]
        public state StateDetails { get; set; }
        [DataMember(Name = "UserDetail")]
        public User UserDetail { get; set; }
        [DataMember(Name = "AppPara")]
        public appparam AppPara { get; set; }
        [DataMember(Name = "DeitTable")]
        public DeitTable DeitTable { get; set; }
        [DataMember(Name = "BasketDetails")]
        public Basket BasketDetails { get; set; }
        [DataMember(Name = "PaymentDetails")]
        public payment PaymentDetails { get; set; }
        [DataMember(Name = "Userselection")]
        public Userselection Userselection { get; set; }
        [DataMember(Name = "CityDetails")]
        public city CityDetails { get; set; }
        [DataMember(Name = "AddressDetails")]
        public address AddressDetails { get; set; }
        [DataMember(Name = "ContactDetails")]
        public Contact ContactDetails { get; set; }
        [DataMember(Name = "ServiceDetails")]
        public Services ServiceDetails { get; set; }
        [DataMember(Name = "Disease")]
        public Disease Disease { get; set; }
        [DataMember(Name = "UserApp")]
        public UserApp UserApp { get; set; }
    }

}