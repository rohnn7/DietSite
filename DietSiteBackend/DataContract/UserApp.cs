using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HealthService.DataContract
{
    [DataContract(Name = "UserApp")]
    public class UserApp
    {

        [DataMember(Name = "UserID")]
        public int UserID { get; set; }
        [DataMember(Name = "Slots")]
        public DateTime Slots { get; set; }
    }
}