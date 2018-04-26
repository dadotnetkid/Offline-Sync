using Jarcet.Qoute.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Models
{
    public partial class Products
    {
        public string NewProductId
        {
            get
            {
                using (var unitofWork = new UnitOfWork())
                {

                    var res = unitofWork.ProductsRepo.Fetch(m => m.CategoryId == this.CategoryId).Select(x => new { ProductId = x.ProductId }).Max(x => x.ProductId) ?? "0-0";
                    var category = unitofWork.CategoriesRepo.Find(m => m.Id == this.CategoryId);
                    var Id = Convert.ToInt32(res.Split('-')[1]) + 1;
                    return category.CategoryName + "-" + Id.ToString("D5");
                }


            }
        }
    }
}