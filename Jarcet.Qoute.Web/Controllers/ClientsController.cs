using DevExpress.Web.Mvc;
using Jarcet.Qoute.Web.Models;
using Jarcet.Qoute.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jarcet.Qoute.Web.Controllers
{
    public class ClientsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ClientsGridViewPartial()
        {
            var model = unitOfWork.ClientsRepo.Get();
            return PartialView("_ClientsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ClientsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Clients item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    item.Id = Guid.NewGuid().ToString();
                    unitOfWork.ClientsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.ClientsRepo.Get();
            return PartialView("_ClientsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ClientsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Clients item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.ClientsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.ClientsRepo.Get();
            return PartialView("_ClientsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ClientsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Clients item)
        {

            if (item != null)
            {
                try
                {
                    unitOfWork.ClientsRepo.Delete(m => m.Id == item.Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.ClientsRepo.Get();
            return PartialView("_ClientsGridViewPartial", model);
        }
        public ActionResult AddEditClientPartial(string ClientId)
        {
            var model = unitOfWork.ClientsRepo.Find(m => m.Id == ClientId);
            return PartialView("_AddEditClientPartial", model);
        }
    }
}