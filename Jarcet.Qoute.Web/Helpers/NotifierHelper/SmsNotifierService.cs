using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Helpers.NotifierHelper
{
    public class SmsNotifierService : INotifierService
    {
        private IMessageService messageService;

        public SmsNotifierService(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        public void Send()
        {
            messageService.SendSms();
        }
    }
}