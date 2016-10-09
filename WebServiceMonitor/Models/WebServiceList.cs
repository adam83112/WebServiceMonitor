using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WebServiceMonitor
{
	[XmlRoot("WebServices")]
	public class WebServiceList
	{
		[XmlElement("WebService")]
		public List<WebService> WebServices { get; set; }
	}
}

