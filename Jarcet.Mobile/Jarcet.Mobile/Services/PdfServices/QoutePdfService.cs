using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Jarcet.Mobile.Models;
using PCLStorage;



namespace Jarcet.Mobile.Services
{
    public class QoutePdfService:IPdfService
    {
        private Qoutes qoutes;

        public QoutePdfService(Qoutes qoutes)
        {
            this.qoutes = qoutes;
        }
        public async void Generate()
        {
           
        }
    }
}
