using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietSite.Models
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
