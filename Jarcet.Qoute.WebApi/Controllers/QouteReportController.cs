using System.Linq;
using System.Web.Http;
using Jarcet.Notifier;
using Jarcet.Qoutes.Reports;
using Jarcet.Qoutes.Reports.QouteReports;
using Jarcet.Repository;
using Microsoft.Azure.Mobile.Server.Config;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    [MobileAppController]
    public class QouteReportController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var model = unitOfWork.QoutesRepo.Get(m => m.Id == Id, includeProperties: "Clients,Users");
                QouteReportService qoute = new QouteReportService(model);
                INotifierService service = new NotifierService(new QouteNotifierService(qoute));
                service.SendEmail(model.FirstOrDefault()?.Users.Email, "Qoutation", "this is sample Qoutation body");
            }
            catch (System.Exception)
            {
                throw;
            }


            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post(string Id)
        {
            try
            {
                var model = unitOfWork.QoutesRepo.Get(m => m.Id == Id, includeProperties: "Clients,Users");
                QouteReportService qoute = new QouteReportService(model);
                INotifierService service = new NotifierService(new QouteNotifierService(qoute));
                service.SendEmail(model.FirstOrDefault()?.Users.Email, "Qoutation", "this is sample Qoutation body");
            }
            catch (System.Exception)
            {
                throw;
            }


            return Ok();

        }

    }
}
