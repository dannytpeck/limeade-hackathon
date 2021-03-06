
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Sitrion AppBuilder.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//    Please use the partial class files to extend this code.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Sitrion.Avalanche.Engine.Interfaces;
using Sitrion.Avalanche.Engine;
using Helpers = Sitrion.Avalanche.Engine.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.Composition;
using System.Globalization;
using Sitrion.Avalanche.Data;
using HackathonMicroApp.Service.DataTypes;
using HackathonMicroApp.Service.Services;

namespace HackathonMicroApp.Service.Services
{
	public abstract class SitrionEntityProjectAppBase : ICloudApplication
	{
		private const string SpecialHandlerName = "SitrionSpecialHandler_";
		public IExecute Gateway { get; set; }
		public string AppId { get { return "416630d6-67cd-41db-816e-5f67180d4368"; } }
		public string StagingAppId { get { return "7177d685-955c-43e4-9405-ea703de1663f"; } }
		public string Name { get { return ""; } }
		public string Description { get { return ""; } }
		public string Version { get { return "1.0"; } }
		public string StorageName { get; set; }
		public Dictionary<string, string> Systems { get; set; }
		public OneContext Context { get; set; }
		public IApplicationLogger Logger { get; set; }
		public IApplicationCache Cache { get; set; }
		public IApplicationStorage Storage { get; set; }
		public IPushCounter Push { get; set; }
		
		public string CategoryApplicationId { get; set; }
		
		protected Appointments_Service s_Appointments_Service = new Appointments_Service();
		protected Scheduled_Service s_Scheduled_Service = new Scheduled_Service();
		protected SelectedAppointment s_SelectedAppointment = new SelectedAppointment();
		
		protected virtual void BeforeInternalInit()
		{
		}
		
		protected virtual void AfterInternalInit() {
		}
		
		public virtual void InternalInit()
		{
			BeforeInternalInit();
			s_Appointments_Service.Application = this;
			s_Scheduled_Service.Application = this;
			s_SelectedAppointment.Application = this;
			AfterInternalInit();
		}
		
		/// <summary>
		/// Override this method to handle binary data for cards and applications. The URL have to be used like this:
		/// https://one.sitrion.com/api/v2/remoteweb/link/?burl=BASE64(sitrion:CATEGORYAPPLICATIONID:SitrionSpecialHandler:YOURID)
		/// </summary>
		/// <param name="Id">The ID which is used in the URL can be switched to return the correct binary.</param>
		/// <param name="contentType">Add a content Type. eg image/jpg.</param>
		/// <param name="fileName">Add a default filename for the binary dump.</param>
		/// <returns>The binary dump of the file.</returns>
		public virtual byte[] OnGetBinaryData ( string Id, out string contentType, out string fileName )
		{
			contentType = null;
			fileName = null;
			return null;
		}
		
		/// <summary>
		/// The ViewModel calls the service method using the Execute method.
		/// </summary>
		/// <param name="message">A wrapper for the "call this service in this class" method</param>
		/// <returns>An ExecuteFunctionMessage which will be bindable by the ViewModel.</returns>
		public virtual ExecuteFunctionMessage Execute ( ExecuteFunctionMessage message )
		{
			this.CategoryApplicationId = message.CategoryApplicationId.ToString();
			InternalInit();
			
			if ( message.MethodName.StartsWith ( SpecialHandlerName ) )
			{
				return ExecuteSpecial ( message );
			}
			
			switch ( message.MethodName )
			{
				case "HackathonMicroAppViewModel_GetAppointmentData":
					{
						System.String p_ZipCode = default ( System.String );
						p_ZipCode = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "ZipCode" );
						HackathonMicroApp.Service.DataTypes.AppointmentData retVal = s_Appointments_Service.GetAppointmentData ( p_ZipCode );
						message.MethodParams.Add ( "GetAppointmentData", retVal );
					}
					break;
					
				case "HackathonMicroAppViewModel_saveScheduledAppointment":
					{
						System.String p_FirstName = default ( System.String );
						System.String p_LastName = default ( System.String );
						System.String p_BirthDate = default ( System.String );
						System.String p_Email = default ( System.String );
						HackathonMicroApp.Service.DataTypes.RecordList p_selectedRecord = default ( HackathonMicroApp.Service.DataTypes.RecordList );
						p_FirstName = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "FirstName" );
						p_LastName = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "LastName" );
						p_BirthDate = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "BirthDate" );
						p_Email = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "Email" );
						p_selectedRecord = Helpers.AppBuilder.GetParameterValue<HackathonMicroApp.Service.DataTypes.RecordList> ( message.MethodParams, "selectedRecord" );
						System.Int32 retVal = s_Scheduled_Service.saveScheduledAppointment ( p_FirstName, p_LastName, p_BirthDate, p_Email, p_selectedRecord );
						message.MethodParams.Add ( "saveScheduledAppointment", retVal );
					}
					break;
			}
			
			return message;
		}
		
		
		
		public virtual ExecuteFunctionMessage ExecuteSpecial ( ExecuteFunctionMessage message )
		{
			switch ( message.MethodName.Replace ( SpecialHandlerName, "" ) )
			{
				case "GetBinaryData":
					{
						System.String p_id = default ( System.String );
						System.String p_contentType = default ( System.String );
						System.String p_fileName = default ( System.String );
						p_id = Helpers.AppBuilder.GetParameterValue<System.String> ( message.MethodParams, "id" );
						p_contentType = default ( System.String );
						p_fileName = default ( System.String );
						System.Byte[] retVal = OnGetBinaryData ( p_id, out p_contentType, out p_fileName );
						message.MethodParams.Add ( "GetBinaryData", retVal );
						
						if ( message.MethodParams.ContainsKey ( "contentType" ) )
						{ message.MethodParams["contentType"] = p_contentType; }
						
						else
						{ message.MethodParams.Add ( "contentType", p_contentType ); }
						
						if ( message.MethodParams.ContainsKey ( "fileName" ) )
						{ message.MethodParams["fileName"] = p_fileName; }
						
						else
						{ message.MethodParams.Add ( "fileName", p_fileName ); }
						
						message.CardAction = Sitrion.Avalanche.Data.CardActionType.None;
						return message;
					}
					
				default:
					return message;
			}
		}
		
	}
}