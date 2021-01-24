using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DietSite
{
    [DataContract(Name ="UserSelection")]
    public class Userselection
    {
        [DataMember(Name ="Userid")]
        public int UserID { get; set; }
        [DataMember(Name ="DeitID")]
        public int DeitID { get; set; }
        [DataMember(Name ="DateofSelection")]
        public DateTime DateofSelection { get; set; }
        [DataMember(Name ="Purchase")]
        public int Purchase { get; set; }

    }
}