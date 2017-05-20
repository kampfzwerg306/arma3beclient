using Akka.Actor;
using Arma3BE.Client.Infrastructure.Events.BE;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Libs.Repositories;
using Prism.Events;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Arma3BE.Client.Modules.BEServerModule.ActorModel
{
    public class ServerCoordinatorActor : ReceiveActor
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ConcurrentDictionary<Guid, IActorRef> _serverPool = new ConcurrentDictionary<Guid, IActorRef>();
        private readonly ILog _log = LogFactory.Create(new StackTrace().GetFrame(0).GetMethod().DeclaringType);

        private IActorRef _self;

        public ServerCoordinatorActor(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Receive<ConnectServerMessage>(message => CheckServer(message.Info));
            Receive<DisConnectServerMessage>(message => CloseServer(message.Info));

            _self = Self;
            _eventAggregator.GetEvent<RunServerEvent>().Subscribe(info => _self.Tell(new ConnectServerMessage(info)), ThreadOption.BackgroundThread);
            _eventAggregator.GetEvent<CloseServerEvent>().Subscribe(info => _self.Tell(new DisConnectServerMessage(info)), ThreadOption.BackgroundThread);
        }

        private void CloseServer(ServerInfoDto info)
        {
            IActorRef item;
            _log.Info($"ServerCoordinatorActor CloseServer {info.Id}");

            if (_serverPool.TryRemove(info.Id, out item))
            {
                item?.Tell(PoisonPill.Instance);
            }
        }

        private void CheckServer(ServerInfoDto info)
        {
            _log.Info($"ServerCoordinatorActor CheckServer {info.Id}");
            _serverPool.AddOrUpdate(info.Id, key => CreateServerActor(info, Context), (id, actor) => actor);
        }

        private IActorRef CreateServerActor(ServerInfoDto info, IUntypedActorContext context)
        {
            _log.Info($"CheckServer CreateServerActor {info.Id}");
            var actor = context.ActorOf(Props.Create(() => new ServerActor(info)), $"Server_{info.Id}");
            return actor;
        }

        protected override void PostStop()
        {
            _log.Info("Post stop for ServerCoordinatorActor");
            var local = _serverPool;
            if (local != null)
            {
                foreach (var actorRef in local)
                {
                    actorRef.Value.Tell(PoisonPill.Instance);
                }
                local.Clear();
            }
        }


        private class ConnectServerMessage
        {
            public ServerInfoDto Info { get; }

            public ConnectServerMessage(ServerInfoDto info)
            {
                Info = info;
            }
        }

        private class DisConnectServerMessage
        {
            public ServerInfoDto Info { get; }

            public DisConnectServerMessage(ServerInfoDto info)
            {
                Info = info;
            }
        }
    }
}