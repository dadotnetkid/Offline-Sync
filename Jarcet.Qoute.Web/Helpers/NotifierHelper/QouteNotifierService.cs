using Jarcet.Qoute.Web.Helpers.NotifierHelper;
using Jarcet.Qoute.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Jarcet.Qoute.Web.Helpers.NotifierHelper
{
    public class QouteNotifierService : IMessageService
    {
        private Qoutes qoutes;
        public QouteNotifierService(Qoutes qoutes)
        {
            this.qoutes = qoutes;
        }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Attachment Attachment { get; set; }

        public void SendEmail(SmtpClient smtpClient, MailMessage mailMessage)
        {
            mailMessage.Attachments.Add(new Attachment(new MemoryStream(), System.Net.Mime.MediaTypeNames.Application.Octet));


            Task.Run(async () =>
            {
                await smtpClient.SendMailAsync(mailMessage);
            });
        }

        public void SendSms()
        {
            throw new NotImplementedException();
        }
    }
}