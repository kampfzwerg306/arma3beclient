using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Unity;
using Microsoft.Practices.Unity;

namespace Arma3BE.Client.Modules.BEServerModule.ActorModel
{
    public class ActorSystemReference
    {
        private readonly ActorSystem _actorSystem;
        private readonly IDependencyResolver _resolver;
        private readonly IActorRef _coordinator;


        public ActorSystemReference(IUnityContainer container)
        {
            _actorSystem = ActorSystem.Create("Arma3BE-Client-Modules-BEServerModule-ActorModel-ActorSystemReference");
            _resolver = new UnityDependencyResolver(container, _actorSystem);
            _coordinator = _actorSystem.ActorOf(_actorSystem.DI().Props(typeof(ServerCoordinatorActor)), "ServerCoordinatorActor");
        }
    }
}