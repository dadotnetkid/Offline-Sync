using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace Jarcet.Qoute.Web.Models
{
    public partial class Users : IUser<string>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Users, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("FullName", this.FullName));
            return userIdentity;
        }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
    }
    public static class IdentityExtension
    {
        public static string GetFullName(this IIdentity user)
        {
            var claimIdent = user as ClaimsIdentity;
            return claimIdent != null
                && claimIdent.HasClaim(c => c.Type == "FullName")
                ? claimIdent.FindFirst("FullName").Value
                : string.Empty;
        }
    }
}