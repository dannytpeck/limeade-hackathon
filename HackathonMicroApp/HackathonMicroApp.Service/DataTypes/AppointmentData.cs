using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HackathonMicroApp.Service.DataTypes
{
    [DataContract]
    public class AppointmentData
    {
        [DataMember]
        public List<RecordList> records { get; set; }
    }
}
