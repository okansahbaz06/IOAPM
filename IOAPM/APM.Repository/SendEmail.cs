using APM.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace APM.Repository
{
    public class SendEmail : ISendEmail
    {
        public void Send(string Subject, string Email, string Body)
        {
            // kimlik bilgileri
            var credentials = new NetworkCredential("erdo992@gmail.com", "qozduyaactczzqtr");

            var mail = new MailMessage()
            {
                From = new MailAddress("erdo992@gmail.com"),
                Subject = Subject,
                Body = Body
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(Email));

            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials,
            };
            client.Send(mail);
        }
    }
}
