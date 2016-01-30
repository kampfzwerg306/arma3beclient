using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Arma3BE.Server;
using Arma3BE.Server.State;
using Arma3BEClient.Common.Logging;
using log4net.Config;

namespace Arma3BE.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var log = new Log();
            StateServer = new StateServer(new BEServer("server2.tehgam.com", 2302, "pass", log, new WatcherBEClientFactory(log)));
        }

        protected void Application_Error()
        {
        }

        public static StateServer StateServer;
    }
}