using System;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;


namespace WebServiceMonitor
{
    [XmlRoot("MailConfig")]
    public class MailSettings
    {
        public string UserName;
        public string Address;
        public string Password;
        public string Host;
        public bool EnableSsl;
        public int Port;
        public bool UseDefaultCredentials;
        public SmtpDeliveryMethod DeliveryMethod;
    }
}

