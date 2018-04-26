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
                "E2EED04CCCED91FD8170172FD529DAB9E32D65CEF7A50F9FE8545921135A77B4",
                "http://192.168.254.102:53197/",
                "http://192.168.254.102:53197/",
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
