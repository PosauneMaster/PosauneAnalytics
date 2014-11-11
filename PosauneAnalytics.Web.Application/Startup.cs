using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PosauneAnalytics.Web.Application.Startup))]
namespace PosauneAnalytics.Web.Application
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
