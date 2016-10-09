using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;

namespace WebServiceMonitor
{
    public class MaliningListConfig
    {
        string fileName;

        public MaliningListConfig(string fileName)
        {
            this.fileName = fileName;
        }

        public List<MailAddress> GetList()
        {
            string testData = File.ReadAllText(fileName);

            XmlSerializer serializer = new XmlSerializer(typeof(MailingList));
            using (TextReader reader = new StringReader(testData))
            {
                var result = (MailingList)serializer.Deserialize(reader);
                return result.Addresses.Select(address => new MailAddress(address)).ToList();
            }
        }
    }
}

