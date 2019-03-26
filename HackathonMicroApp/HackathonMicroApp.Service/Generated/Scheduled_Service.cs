

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
	
	[OneService ( SystemTypeName = "REST WebServices", SystemInstanceName = "Scheduled", EndpointName = "WellMetrics Scheduled" )]
	public partial class Scheduled_Service
	{
		public ICloudApplication Application { get; set; }
	}
}
