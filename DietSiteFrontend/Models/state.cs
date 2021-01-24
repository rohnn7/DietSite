using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DietSite
{
    [DataContract(Name = "state")]
    public class state
    {
        [DataMember (Name ="stateid")]
        public int Stateid { get; set; }
        [DataMember (Name ="statename")]
        public string Statename { get; set; }

    }
}