using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DietSite
{
    [DataContract(Name = "User")]
    public class User
    {
        [DataMember(Name = "Userid")]
        public int UserID { get; set; }
        [DataMember(Name = "UserName")]
        public string Name { get; set; }
        [DataMember(Name = "sex")]
        public int Sex { get; set; }
        [DataMember(Name = "DOB")]
        public DateTime DOB { get; set; }
        [DataMember(Name = "Height")]
        public int Height { get; set; }
        [DataMember(Name = "Weight")]
        public int Weight { get; set; }
        [DataMember(Name = "Username")]
        public string Username { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        [DataMember(Name = "Cityname")]
        public string CityName { get; set; }
        
    }


}
