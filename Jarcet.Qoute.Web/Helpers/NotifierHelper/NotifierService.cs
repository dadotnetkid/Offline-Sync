using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Helpers.NotifierHelper
{
    public class NotifierService: INotifierService
    {
        private INotifierService notifierService;

        public NotifierService(INotifierService notifierService)
        {
            this.notifierService = notifierService;
        }

        public void Send()
        {
            notifierService.Send();
        }
    }
}