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
    public class EmailNotifierService : INotifierService
    {
        private IMessageService messageModel;
        private SmtpClient smtpClient;
        private MailMessage mailMessage;

        public EmailNotifierService(IMessageService messageModel)
        {
            this.messageModel = messageModel;
            this.smtpClient = new SmtpClient("smtp.gmail.com", 587);
        }
       
        public void Send()
        {
            mailMessage = new MailMessage(this.messageModel.From, messageModel.To, messageModel.Subject, messageModel.Body);
           
            messageModel.SendEmail(smtpClient,mailMessage);
        }
    }
}