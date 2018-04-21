using DevExpress.Web.Mvc;
using Jarcet.Qoute.Web.Helpers.NotifierHelper;
using Jarcet.Qoute.Web.Models;
using Jarcet.Qoute.Web.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jarcet.Qoute.Web.Controllers
{
    public class QoutesController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.QouteId = Guid.NewGuid().ToString();
            return View();
        }

        #region Qoutes
        [ValidateInput(false)]
        public ActionResult QoutesGridViewPartial()
        {
            // Session["newQoute"] = Guid.NewGuid().ToString();
            Session["QouteDetails"] = new List<QouteDetails>();

            var model = unitOfWork.QoutesRepo.Get(includeProperties: "Clients");

            return PartialView("_QoutesGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QoutesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Qoutes item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    item.Id = Guid.NewGuid().ToString();
                    foreach (var i in Session["QouteDetails"] as List<QouteDetails>)
                    {
                        i.Products = null;
                        item.QouteDetails.Add(i);
                    }
                    item.UserId = User.Identity.GetUserId();
                    unitOfWork.QoutesRepo.Insert(item);
                    unitOfWork.Save();


                    /*  QouteNotifierService qouteNotifierService = new QouteNotifierService(item);
                      INotifierService notifier = new EmailNotifierService(qouteNotifierService);
                      notifier.Send();*/
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.QoutesRepo.Get(includeProperties: "Clients");
            return PartialView("_QoutesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QoutesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Qoutes item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_QoutesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QoutesGridViewPartialDelete(System.String Id)
        {
            var model = new object[0];
            if (Id != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_QoutesGridViewPartial", model);
        }
        [ChildActionOnly]
        public ActionResult AddEditQoutesPartial(string QouteId)
        {
            var model = unitOfWork.QoutesRepo.Find(m => m.Id == QouteId);
            ViewBag.QouteId = QouteId;
            return PartialView("_AddEditQoutesPartial", model);
        }
        #endregion



        #region QouteDetails
        [ValidateInput(false)]
        public ActionResult QouteDetailsGridViewPartial(string QouteId, bool? isVisibleCommandColumn = false)
        {
            /* ViewBag.isVisibleCommandColumn = isVisibleCommandColumn;
             ViewBag.QouteId = QouteId;
             var model = unitOfWork.QouteDetailsRepo.Get(m => m.QouteId == QouteId, includeProperties: "Products");
             ViewBag.Total = model.Sum(m => m.Total);*/
            var model = Session["QouteDetails"] as IEnumerable<QouteDetails>;
            if (QouteId != "" && QouteId != null)
            {
                model = unitOfWork.QouteDetailsRepo.Get(m => m.QouteId == QouteId);
                isVisibleCommandColumn = true;
            }


            ViewBag.Total = model.Sum(m => m.Total);
            ViewBag.isVisibleCommandColumn = isVisibleCommandColumn;
            return PartialView("_QouteDetailsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QouteDetailsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] QouteDetails item)
        {
            /* var ClientId = Request.Params["ClientId"];

             ViewBag.isVisibleCommandColumn = Convert.ToBoolean(Request.Params["isVisibleCommandColumn"]);*/
            var model = Session["QouteDetails"] as List<QouteDetails>;
            if (ModelState.IsValid)
            {
                try
                {
                    /* item.Id = Guid.NewGuid().ToString();
                     item.Qty = item.Qty <= 0 || item.Qty == null ? 1 : item.Qty;
                     item.Qoutes = unitOfWork.QoutesRepo.Find(m => m.Id == item.QouteId) ?? new Qoutes() { Id = item.QouteId, ClientId = ClientId ,UserId=User.Identity.GetUserId()};
                     unitOfWork.QouteDetailsRepo.Insert(item);
                     unitOfWork.Save();
                        var session = Session["QouteDetails"] as List<QouteDetails>;
                    session.Add(item);
                    Session["QouteDetails"] = session;
                     */
                    item.Id = Guid.NewGuid().ToString();
                    item.Qty = item.Qty <= 0 || item.Qty == null ? 1 : item.Qty;


                    item.Products = unitOfWork.ProductsRepo.Find(m => m.Id == item.ProductId);
                    model.Add(item);
                    //Session["QouteDetails"] = model;
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            /*     var model = unitOfWork.QouteDetailsRepo.Get(m => m.QouteId == item.QouteId, includeProperties: "Products");
                 ViewBag.Total = model.Sum(m => m.Total);*/

            ViewBag.Total = model.Sum(m => m.Total);
            ViewBag.isVisibleCommandColumn = Convert.ToBoolean(Request.Params["isVisibleCommandColumn"]);
            return PartialView("_QouteDetailsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QouteDetailsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] QouteDetails item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_QouteDetailsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QouteDetailsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] QouteDetails item)
        {
            if (item != null)
            {
                try
                {
                    unitOfWork.QouteDetailsRepo.Delete(m => m.Id == item.Id);
                    unitOfWork.Save();
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.QouteDetailsRepo.Get(m => m.QouteId == item.QouteId, includeProperties: "Products");
            ViewBag.Total = model.Sum(m => m.Total);
            ViewBag.isVisibleCommandColumn = Convert.ToBoolean(Request.Params["isVisibleCommandColumn"]);
            return PartialView("_QouteDetailsGridViewPartial", model);
        }
        public ActionResult EditAddQouteDetailsPartial(string QouteDetailsId)
        {
            var model = unitOfWork.QouteDetailsRepo.Find(m => m.Id == QouteDetailsId);
            return PartialView("_EditAddQouteDetailsPartial", model);
        }
        public ActionResult ProductDetailPartial(string ProductId)
        {
            var model = unitOfWork.ProductsRepo.Find(m => m.Id == ProductId);
            ViewBag.Products = model;
            return PartialView("_EditAddQouteDetailsPartial");
        }

        public ActionResult AddNewQoutePartial()
        {
            return View();
        }
        #endregion






















    }
}