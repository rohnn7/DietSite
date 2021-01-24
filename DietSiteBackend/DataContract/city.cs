using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.DataContract
{
    [DataContract (Name ="City")]
    public class city
    {
        [DataMember(Name ="Cid")]
        public int CID { get; set; }
        [DataMember(Name ="Cityname")]
        public string CityName { get; set; }
    }
}