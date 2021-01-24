using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace DietSite
{
    [DataContract(Name ="Appparam")]
    public class appparam
    {
        [DataMember(Name ="AppParamID")]
        public int AppParamID { get; set; }
        [DataMember(Name ="MorningScheduleBegin")]
        public DateTime MorinigScheduleBegin { get; set; }
        [DataMember (Name ="MorningScheduleEnds")]
        public DateTime MorningScheduleEnds { get; set; }
        [DataMember(Name ="AfternoonScheduleBegins")]
        public DateTime AfternoonScheduleBegins { get; set; }
        [DataMember(Name ="AfternoonScheduleEnds")]
        public DateTime AfternoonSCheduleEnds { get; set; }
        [DataMember (Name ="Offday")]
        public int Offday { get; set; }
        [DataMember(Name ="enabled")]
        public int Enabled { get; set; }
        [DataMember(Name ="avgtime")]
        public int Avgtime { get; set; }
        [DataMember(Name = "CityID")]
        public int CityID { get; set; }
        [DataMember(Name = "CityName")]
        public string CityName { get; set; }
        [DataMember(Name = "stateid")]
        public int Stateid { get; set; }
        [DataMember(Name = "Cid")]
        public int CID { get; set; }

        [DataMember(Name = "AppparamID")]
        public int AppparamID { get; set; }
        [DataMember(Name = "Datefrom")]
        public DateTime Datefrom { get; set; }
        [DataMember(Name = "Dateto")]
        public DateTime Dateto { get; set; }
        [DataMember(Name ="Outcity")]
        public string Outcity { get; set; }





    }
}