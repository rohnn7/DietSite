using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DietSite
{
    [DataContract (Name ="Contact")]
    public class Contact
    {
        [DataMember(Name = "ContactID")]
        public int ContactId { get; set; }
        [DataMember(Name = "MobileNo")]
        public string MobileNo { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "Userid")]
        public int UserID { get; set; }
    }
}