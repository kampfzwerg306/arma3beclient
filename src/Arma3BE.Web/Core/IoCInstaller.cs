using System;
using System.Web.Mvc;
using System.Web.Routing;
using Arma3BEClient.Common.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Arma3BE.Web.Core
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILog>().ImplementedBy<Log>()
                );

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }

        public class WindsorControllerFactory : DefaultControllerFactory
        {
            readonly IWindsorContainer container;
            public WindsorControllerFactory(IWindsorContainer container)
            {
                this.container = container;
            }

            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                if (controllerType != null && container.Kernel.HasComponent(controllerType))
                    return (IController)container.Resolve(controllerType);
                return base.GetControllerInstance(requestContext, controllerType);
            }

            public override void ReleaseController(IController controller)
            {
                container.Release(controller);
            }
        }
    }
}