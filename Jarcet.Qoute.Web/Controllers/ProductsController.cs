using DevExpress.Web.Mvc;
using Jarcet.Qoute.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jarcet.Qoute.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ProductsGridViewPartial()
        {
            var model = unitOfWork.ProductsRepo.Get();
            return PartialView("_ProductsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Products item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    item.ProductId = item.NewProductId;
                    item.Id = Guid.NewGuid().ToString();
                    unitOfWork.ProductsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.ProductsRepo.Get();
            return PartialView("_ProductsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Products item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.ProductsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.ProductsRepo.Get();
            return PartialView("_ProductsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Jarcet.Qoute.Web.Models.Products item)
        {

            if (item != null)
            {
                try
                {
                    unitOfWork.ProductsRepo.Delete(m => m.Id == item.Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.ProductsRepo.Get();
            return PartialView("_ProductsGridViewPartial", model);
        }
        public ActionResult AddEditProductPartial(string ProductId)
        {
            var model = unitOfWork.ProductsRepo.Find(m => m.Id == ProductId);
            return PartialView("_AddEditProductPartial", model);
        }
    }
}