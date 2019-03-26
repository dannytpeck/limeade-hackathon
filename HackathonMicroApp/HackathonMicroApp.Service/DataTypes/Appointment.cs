using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HackathonMicroApp.Service.DataTypes
{
    public class Appointment
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string appointment_status { get; set; }
        public string[] appointment_link { get; set; }
        public string birth_date { get; set; }
        public string email { get; set; }
    }
}
