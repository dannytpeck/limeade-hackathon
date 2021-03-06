

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
	
	public partial class Appointments_Service
	{
        public AppointmentData AppointmentData { get; set; }

        public AppointmentData GetAppointmentData(string ZipCode)
        {   
            var request = new ExecutionRequest();
            request.EntityToExecuteAgainst = new ExecutionEntity();
            request.EntityToExecuteAgainst.EntityName = "SampleCall";

            var urlFragment = "?api_key=keyCxnlep0bgotSrX";
            if (ZipCode != null && ZipCode.Length == 5)
            {
                urlFragment = "?api_key=keyCxnlep0bgotSrX&filterByFormula=({appointment_location_zip}=" + ZipCode + ")";
            }

            var webRequest = new RemoteWebRequest()
            {
                RelativeAddress = $"" + urlFragment,
                BodyContent = null, // Convert your data to Json, eg JsonConvert.SerializeObject(myObj),
                Method = "GET"
            };
            request.Parameters.Add("request", webRequest);
            var response = Runtime.SendRequest(request);
            var result = JsonConvert.DeserializeObject<RemoteWebResponse>(response.ReturnParameters["result"] as string);
            // Handle your result data in result.Response!

            AppointmentData = JsonConvert.DeserializeObject<AppointmentData>(result.Response);
            return AppointmentData;
        }
    }
}
