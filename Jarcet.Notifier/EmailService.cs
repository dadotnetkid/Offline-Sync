using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Notifier
{
    public class EmailService 
    {
        public SmtpClient smtpClient { get; set; }
        public MailMessage mailMessage { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public Attachment attachment { get; set; }
        public EmailService()
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            this.From = "markchristopher.cacal@gmail.com";
            smtpClient.Credentials = new NetworkCredential(this.From, "sldd140124");

        }
        public EmailService(Attachment attachment)
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            this.From = "markchristopher.cacal@gmail.com";
            smtpClient.Credentials = new NetworkCredential(this.From, "sldd140124");
            this.attachment = attachment;
        }

        public void SendEmail(string to, string subject, string body)
        {
            this.mailMessage = new MailMessage(this.From, to, subject, body);
            mailMessage.Attachments.Add(attachment);
            Task.Run(async () =>
            {
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            });
        }

        public void SendText()
        {
            throw new NotImplementedException();
        }
    }
}
