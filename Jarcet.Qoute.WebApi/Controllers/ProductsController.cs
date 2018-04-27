using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Jarcet.Qoutes.WebApi.Models;
using Jarcet.Qoutes.WebApi.Services;
using Jarcet.Models;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    public class ProductsController : TableController<Products>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            QouteMobileContext context = new QouteMobileContext();
            DomainManager = new EntityDomainManager<Products>(context, Request);
        }

        // GET tables/Products
        [ExpandProperty("Categories")]
        public IQueryable<Products> GetAllProducts()
        {
            return Query(); 
        }

        // GET tables/Products/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Products> GetProducts(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Products/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Products> PatchProducts(string id, Delta<Products> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Products
        public async Task<IHttpActionResult> PostProducts(Products item)
        {
            Products current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Products/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteProducts(string id)
        {
             return DeleteAsync(id);
        }
    }
}
