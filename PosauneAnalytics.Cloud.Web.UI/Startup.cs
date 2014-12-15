using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PosauneAnalytics.Cloud.Web.UI.Startup))]
namespace PosauneAnalytics.Cloud.Web.UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
