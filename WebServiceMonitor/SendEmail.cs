using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace WebServiceMonitor
{
    public class SendEmail
    {
        MailSettings mailSettings;

        public SendEmail()
        {
            mailSettings = new MailConfig("mailconfig.xml").GetSettings();
        }

        public void Send(List<MailAddress> recipients, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                EnableSsl = mailSettings.EnableSsl,
                DeliveryMethod = mailSettings.DeliveryMethod,
                UseDefaultCredentials = mailSettings.UseDefaultCredentials,
                Credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password)
            };


            using (var message = new MailMessage())
            {
                message.Subject = subject;
                message.Body = body;
                message.From = new MailAddress(mailSettings.Address);
                recipients.ForEach(address => message.To.Add(address));
                smtp.Send(message);
            }

        }
    }
}

