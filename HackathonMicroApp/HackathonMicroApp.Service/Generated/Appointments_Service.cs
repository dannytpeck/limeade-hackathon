

namespace HackathonMicroApp.Service.Services
{
	using Sitrion.ServiceStudio.Activities;
	using Sitrion.One.Runtime;
	using Sitrion.ServiceStudio.RESTAdapter.Runtime;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Newtonsoft.Json;
	using System.Runtime.Serialization;
	using Sitrion.Avalanche.Engine.Interfaces;
	using HackathonMicroApp.Service.DataTypes;
	
	[OneService ( SystemTypeName = "REST WebServices", SystemInstanceName = "Appointments", EndpointName = "Wellmetrics Appointments" )]
	public partial class Appointments_Service
	{
		public ICloudApplication Application { get; set; }
	}
}
