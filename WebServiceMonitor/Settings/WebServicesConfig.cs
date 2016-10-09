using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WebServiceMonitor
{
	public class WebServicesConfig
	{
		string fileName;

		public WebServicesConfig(string fileName)
		{
			this.fileName = fileName;
		}

		public List<WebService> GetWebServices()
		{
			string testData = File.ReadAllText(fileName);

			XmlSerializer serializer = new XmlSerializer(typeof(WebServiceList));
			using (TextReader reader = new StringReader(testData))
			{
				WebServiceList result = (WebServiceList)serializer.Deserialize(reader);
				return result.WebServices;
			}
		}
	}
}

