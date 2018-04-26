using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Jarcet.Qoutes.WebApi.Models;
using System.Data.Entity;
using System.Diagnostics;
using Jarcet.Qoutes.WebApi.Services;
using Microsoft.AspNet.Identity;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    [Authorize]
    public class QoutesController : TableController<Models.Qoutes>
    {
        private QouteMobileContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new QouteMobileContext();
            Debug.WriteLine("controllerContext " + controllerContext.Request.Content.ReadAsStringAsync().Result);
            DomainManager = new EntityDomainManager<Models.Qoutes>(context, Request);
        }

        // GET tables/Qoute
        [ExpandProperty("Clients,Users")]
        public IQueryable<Models.Qoutes> GetAllQoute()
        {
            return Query();
        }

        // GET tables/Qoute/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Models.Qoutes> GetQoute(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Qoute/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Models.Qoutes> PatchQoute(string id, Delta<Models.Qoutes> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Qoute
        public async Task<IHttpActionResult> PostQoute(Models.Qoutes item)
        {
            try
            {
                item.UserId = User.Identity.GetUserId();

                if (!ModelState.IsValid)
                {
                    Debug.WriteLine(BadRequest(ModelState));
                }

                item.QouteDetails.ToList().ForEach(x =>
                {
                    x.Products = null;
                });

                var current = await InsertAsync(item);
                return CreatedAtRoute("Tables", new { id = current.Id }, current);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                Debug.WriteLine(ex.Message);
            }




        }

        // DELETE tables/Qoute/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteQoute(string id)
        {
            return DeleteAsync(id);
        }
    }
}
