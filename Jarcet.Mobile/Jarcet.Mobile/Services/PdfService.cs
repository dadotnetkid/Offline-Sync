using System;
using System.Collections.Generic;
using System.Text;

namespace Jarcet.Mobile.Services
{
   public  class PdfService:IPdfService
    {
        private IPdfService pdfService;

        public PdfService(IPdfService pdfService)
        {
            this.pdfService = pdfService;
        }
        public void Generate()
        {
            this.pdfService.Generate();
        }
    }
}
