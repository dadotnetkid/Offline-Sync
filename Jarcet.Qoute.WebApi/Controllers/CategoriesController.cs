using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Jarcet.Qoutes.WebApi.Models;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    public class CategoriesController : TableController<Categories>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            QouteMobileContext context = new QouteMobileContext();
            DomainManager = new EntityDomainManager<Categories>(context, Request);
        }

        // GET tables/Categories
        public IQueryable<Categories> GetAllCategories()
        {
            return Query(); 
        }

        // GET tables/Categories/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Categories> GetCategories(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Categories/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Categories> PatchCategories(string id, Delta<Categories> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Categories
        public async Task<IHttpActionResult> PostCategories(Categories item)
        {
            Categories current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Categories/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCategories(string id)
        {
             return DeleteAsync(id);
        }
    }
}
