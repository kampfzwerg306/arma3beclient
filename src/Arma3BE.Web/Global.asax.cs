using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Arma3BE.Server;
using Arma3BE.Server.State;
using Arma3BE.Web.Core;
using Arma3BEClient.Common.Logging;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
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
            ConfigureWindsor(GlobalConfiguration.Configuration);

            var log = new Log();
            StateServer = new StateServer(new BEServer("server2.tehgam.com", 2302, "password", log, new WatcherBEClientFactory(log)));
        }

        protected void Application_Error()
        {
            var e = Server.GetLastError();
            var t = 10;
        }

        public static StateServer StateServer;



        private static IWindsorContainer _container;

       

        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;

        }

        protected void Application_End()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}