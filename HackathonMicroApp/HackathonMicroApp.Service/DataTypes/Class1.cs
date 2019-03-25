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

    [DataContract]
    public class RecordList
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public FieldList fields;
        public string createdTime { get; set; }
    }

    [DataContract]
    public class FieldList
    {
        [DataMember]
        public string appointment_ref { get; set; }
        [DataMember]
        public string client_name { get; set; }
        [DataMember]
        public string appointment_location_name { get; set; }
        [DataMember]
        public string appointment_location_zip { get; set; }
        [DataMember]
        public string appointment_time { get; set; }
        [DataMember]
        public string appointment_id { get; set; }
        [DataMember]
        public int appointments_filled { get; set; }
        [DataMember]
        public int appointments_max { get; set; }
        [DataMember]
        public string appointments_status { get; set; }
        [DataMember]
        public string appointment_time_string { get; set; }
    }
}
