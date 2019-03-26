using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Sitrion.Avalanche.Engine.Interfaces;
using Sitrion.Avalanche.Engine;
using Sitrion.Avalanche.Engine.Model;
using Sitrion.Avalanche.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Composition;
using System.Globalization;
using Sitrion.ServiceStudio.Activities;
using System.Runtime.Serialization;
using HackathonMicroApp.Service.DataTypes;

namespace HackathonMicroApp.Service.Services
{
	[OneService]
	public class SelectedAppointment
	{
		public ICloudApplication Application { get; set; }
    }
    
}