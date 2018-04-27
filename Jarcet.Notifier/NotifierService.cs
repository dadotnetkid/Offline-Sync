using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Notifier
{
    public class NotifierService: INotifierService
    {
        private INotifierService service;

        public NotifierService(INotifierService service)
        {
            this.service = service;
           
        }

        public void SendEmail(string to, string subject, string body)
        {
            service.SendEmail(to,subject,body);
        }

        public void SendText()
        {
            throw new NotImplementedException();
        }

      
    }
}

