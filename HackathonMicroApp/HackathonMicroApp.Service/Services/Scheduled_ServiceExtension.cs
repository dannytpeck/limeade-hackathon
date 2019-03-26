

namespace HackathonMicroApp.Service.Services
{
	using Sitrion.ServiceStudio.Activities;
	using Sitrion.One.Runtime;
	using Sitrion.ServiceStudio.RESTAdapter.Runtime;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Newtonsoft.Json;
	using HackathonMicroApp.Service.DataTypes;
	
	public partial class Scheduled_Service
	{
        public int saveScheduledAppointment(string FirstName, string LastName, string BirthDate, string Email, RecordList selectedRecord)
        {
            var request = new ExecutionRequest();
            request.EntityToExecuteAgainst = new ExecutionEntity();
            request.EntityToExecuteAgainst.EntityName = "SampleCall";

            Appointment appointment = new Appointment();
            appointment.first_name = FirstName;
            appointment.last_name = LastName;
            appointment.appointment_status = "scheduled";
            appointment.appointment_link = new string[] { selectedRecord.id };
            appointment.birth_date = BirthDate;
            appointment.email = Email;

            Record record = new Record();
            record.fields = appointment;

            var webRequest = new RemoteWebRequest()
            {
                RelativeAddress = $"?api_key=keyCxnlep0bgotSrX",
                BodyContent = JsonConvert.SerializeObject(record),
                Method = "POST"
            };
            request.Parameters.Add("request", webRequest);
            var response = Runtime.SendRequest(request);
            var result = JsonConvert.DeserializeObject<RemoteWebResponse>(response.ReturnParameters["result"] as string);

            return 0;
        }

    }
}
