using System;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Jarcet.Qoutes.WebApi.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Login;

namespace Jarcet.Qoutes.WebApi.Controllers
{
    [MobileAppController]
    [Route(".auth/login/custom")]
    public class MemberController : ApiController
    {
        private ApplicationUserManager userManager;

        public MemberController()
        {
            userManager = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(LoginViewModel model)
        {

            var user = await userManager.FindAsync(model.UserName, model.Password);
            if (user == null)
            {
                return BadRequest("Invalid User and Password");
            }

            var claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id), new Claim("UserName", user.UserName), new Claim("UserId", user.Id) };
            JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
                claims,
                EnvironmentVariables.SigningKey,
                EnvironmentVariables.Website,
                EnvironmentVariables.Website,
                TimeSpan.FromDays(7));

            return Ok(new
            {
                AuthenticationToken = token.RawData,
                User = new
                {
                    UserId = user.Id,
                    UserName = user.UserName
                }

            });
        }
    }
}
