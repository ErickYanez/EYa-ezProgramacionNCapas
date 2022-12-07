using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;

namespace SL_WCF
{
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
        [DataMember]
        public Object Objeto { get; set; }
        [DataMember]
        public List<Object> Objects { get; set; }
    }
}