using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HackathonMicroApp.Service.DataTypes
{
    [DataContract]
    public class RecordList
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public FieldList fields;
        public string createdTime { get; set; }
    }
}
