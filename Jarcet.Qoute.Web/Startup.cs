using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jarcet.Qoute.Web.Startup))]
namespace Jarcet.Qoute.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
