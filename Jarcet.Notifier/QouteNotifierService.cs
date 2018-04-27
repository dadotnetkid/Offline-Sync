using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Qoutes.Reports;

namespace Jarcet.Notifier
{
    public class QouteNotifierService : INotifierService
    {
        private IReportService service;

        public QouteNotifierService(IReportService service)
        {
            this.service = service;
        }



        public async void SendEmail(string to, string subject, string body)
        {
            
            var attachment = new Attachment(service.ExportToStream(), "Attachment"+".pdf", "application/pdf");
            new EmailService(attachment).SendEmail(to, subject, body);
        }

        public void SendText()
        {

        }


    }
}
