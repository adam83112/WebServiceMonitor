using System;
using System.Net;

namespace WebServiceMonitor
{
	[Serializable()]
	public class WebService
	{
		public string Name { get; set; }
		public string Url { get; set; }
        public HttpStatusCode Status { get; set; }

		public bool IsOk
		{ 
			get
			{ 
				return Status == HttpStatusCode.OK; 
			}
		}
	}
}