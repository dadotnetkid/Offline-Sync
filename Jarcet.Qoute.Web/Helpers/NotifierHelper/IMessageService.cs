using System.Net.Mail;

namespace Jarcet.Qoute.Web.Helpers.NotifierHelper
{
    public interface IMessageService
    {
        string Body { get; set; }
        string Subject { get; set; }
        string From { get; set; }
        string To { get; set; }
        Attachment Attachment { get; set; }
        void SendEmail(SmtpClient smtpClient,MailMessage mailMessage);
        void SendSms();
    }
}