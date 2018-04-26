using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Jarcet.Qoutes.WebApi.Startup))]

namespace Jarcet.Qoutes.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}