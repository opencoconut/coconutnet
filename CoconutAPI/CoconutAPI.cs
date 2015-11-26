using System;
using RestSharp;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Net;

namespace Coconut
{
	public class CoconutAPI
	{
		RestClient Cli;
		JavaScriptSerializer Json;

		/// <summary>
		/// Create an CoconutClient instance
		/// </summary>
		/// <param name="APIKey"></param>
		/// <example>
		/// CoconutClient Coconut = new CoconutClient("k-myapikey");
		/// </example>
		public CoconutAPI (string APIKey)
		{
			Cli = new RestClient("https://api.coconut.co");
			Cli.Authenticator = new HttpBasicAuthenticator(APIKey, "");
			Cli.AddDefaultHeader("Accept", "application/json");
			Cli.UserAgent = "Coconut/2.0.0 (dotnet)";

			Json = new JavaScriptSerializer();
		}


		/// Create a Job
		/// </summary>
		/// <param name="Data">A string representing the config content</param>
		/// <returns>CoconutJob instance</returns>
		public CoconutJob Submit(string Data)
		{
			return Json.Deserialize<CoconutJob>(Request("v1/job", Method.POST, Data));
		}

		private string Request(string path, RestSharp.Method method, string Data) {
			var request = new RestRequest(path, method);
			request.AddParameter("text/plain", Data, ParameterType.RequestBody);

			RestResponse response = Cli.Execute(request);
			var code = response.StatusCode;

			if(code == HttpStatusCode.Created || code == HttpStatusCode.OK || code == HttpStatusCode.NoContent)
			{
				return response.Content;
			}
			else
			{
				string ErrorMessage = Json.Deserialize<CoconutError> (response.Content).Message;
				throw new CoconutException(ErrorMessage);
			}

		}
	}
}