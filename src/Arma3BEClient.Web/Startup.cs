using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arma3BEClient.Web.Startup))]
namespace Arma3BEClient.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
