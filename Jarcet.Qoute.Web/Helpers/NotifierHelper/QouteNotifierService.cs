using Jarcet.Qoute.Web.Helpers.NotifierHelper;
using Jarcet.Qoute.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private IEnumerable<Qoutes> qoutesList;

        public QouteNotifierService(Qoutes qoutes)
        {
            this.qoutes = qoutes;
        }
        public QouteNotifierService(IEnumerable<Qoutes> qoutesList, string Subject, string Body, string To)
        {
            this.qoutesList = qoutesList;
            this.Subject = Subject;
            this.Body = Body;
            this.To = To;
            this.From = "markchristopher.cacal@gmail.com";
        }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Attachment Attachment { get; set; }

        public void SendEmail(SmtpClient smtpClient, MailMessage mailMessage)
        {

            AttachmentSetting(mailMessage);
            Task.Run(async () =>
            {
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }
            });
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }

        public void SendSms()
        {
            throw new NotImplementedException();
        }
        void AttachmentSetting(MailMessage mailMessage)
        {
            QouteReports reports = new QouteReports() { DataSource = qoutesList };
            Stream ms = new MemoryStream();
            reports.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.EnableCopying = false;
            reports.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsPassword = this.To;
            reports.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = this.To;
            reports.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsOptions.ChangingPermissions = DevExpress.XtraPrinting.ChangingPermissions.None;
            reports.ExportToPdf(ms);

            ms.Seek(0, SeekOrigin.Begin);
            mailMessage.Attachments.Add(new Attachment(ms, mailMessage.Subject + ".pdf", "application/pdf"));
        }
    }
}