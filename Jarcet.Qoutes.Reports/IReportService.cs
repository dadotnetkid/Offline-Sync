using System.IO;

namespace Jarcet.Qoutes.Reports
{
    public interface IReportService
    {
        Stream ExportToStream();
        Stream stream { get; set; }
    }
}