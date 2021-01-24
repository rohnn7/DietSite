using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DietSite
{
    [DataContract (Name ="Payment")]
    public class payment
    {
        [DataMember(Name ="PaymentID")]
        public int PaymentId { get; set; }
        [DataMember(Name ="PaymentDate")]
        public DateTime PaymentDate { get; set; }
        [DataMember(Name ="PaymentReference")]
        public int PaymentReference { get; set; }

        [DataMember(Name = "BasketID")]
        public int BasketID { get; set; }
    }
}