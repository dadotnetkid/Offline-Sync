using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Qoutes.Reports.QouteReports
{
    public class QouteReportService : IReportService
    {
        private IEnumerable< Models.Qoutes> model;

        public QouteReportService( IEnumerable<Models.Qoutes> model)
        {
            this.model = model;
        }
        public Stream ExportToStream()
        {
            QouteReport report = new QouteReport() { DataSource = model };
            var client = model.FirstOrDefault()?.Clients;
            Stream ms = new MemoryStream();
            report.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = client?.LastName;
            report.ExportOptions.Pdf.PasswordSecurityOptions.PermissionsPassword = client?.LastName;
            report.ExportToPdf(ms);
            ms.Seek(0, SeekOrigin.Begin);
          return ms;
        }

        public Stream stream { get; set; }
    }
}
