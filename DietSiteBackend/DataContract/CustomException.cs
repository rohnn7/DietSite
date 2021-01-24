using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HealthService.DataContract
{
    [DataContract(Name = "customexception")]
    public class CustomException
    {
        [DataMember(Name = "title")]
        public string Title;
        [DataMember(Name = "statuscode")]
        public int o_statusCode;
        [DataMember(Name = "statusmessage")]
        public string o_statusMessage;
    }
}