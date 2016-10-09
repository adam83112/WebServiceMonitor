using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Net.Mail;

namespace WebServiceMonitor
{
    public class MailConfig
    {
        string fileName;

        public MailConfig(string fileName)
        {
            this.fileName = fileName;
        }

        public MailSettings GetSettings()
        {
            string testData = File.ReadAllText(fileName);

            XmlSerializer serializer = new XmlSerializer(typeof(MailSettings));
            using (TextReader reader = new StringReader(testData))
            {
                var result = (MailSettings)serializer.Deserialize(reader);
                return result;
            }
        }
    }   
}

