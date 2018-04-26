using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Jarcet.Qoutes.WebApi.Models;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    public class ClientsController : TableController<Clients>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            QouteMobileContext context = new QouteMobileContext();
            DomainManager = new EntityDomainManager<Clients>(context, Request);
        }

        // GET tables/Clients
        public IQueryable<Clients> GetAllClients()
        {
            return Query(); 
        }

        // GET tables/Clients/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Clients> GetClients(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Clients/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Clients> PatchClients(string id, Delta<Clients> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Clients
        public async Task<IHttpActionResult> PostClients(Clients item)
        {
            Clients current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Clients/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteClients(string id)
        {
             return DeleteAsync(id);
        }
    }
}
