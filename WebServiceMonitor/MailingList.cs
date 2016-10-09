using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebServiceMonitor
{
    [XmlRoot("MaliningList")]
    public class MailingList
    {
        [XmlElement("Address")]
        public List<string> Addresses { get; set; }
    }
}

