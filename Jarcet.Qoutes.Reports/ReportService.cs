using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Qoutes.Reports
{
   public class ReportService:IReportService
    {
        private IReportService service;

        public ReportService(IReportService service)
        {
            this.service = service;
        }
        public Stream ExportToStream()
        {
            return service.ExportToStream();
        }

        public Stream stream { get; set; }
    }
}
