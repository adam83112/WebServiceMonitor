using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;

namespace WebServiceMonitor
{
    class SendRaportByEmail : IObserver
    {
        private SendFailureRaports sendRaports;

        public SendRaportByEmail(SendFailureRaports sendRaports)
        {
            this.sendRaports = sendRaports;
        }


        public void Notify()
        {
            var recipients = new MaliningListConfig("emails.xml").GetList();
         
            string subject = "Some services are not working!";

            var servicesNames = sendRaports.Services.Select(service => service.Name);
            var joinedNames = string.Join(", ", servicesNames);
            string body = string.Format("These services are not working: {0}", joinedNames);

            var gmail = new SendEmail();
            gmail.Send(recipients, subject, body);
        }
    }
}

