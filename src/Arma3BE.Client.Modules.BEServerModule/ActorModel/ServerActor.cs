using Akka.Actor;
using Arma3BEClient.Libs.Repositories;

namespace Arma3BE.Client.Modules.BEServerModule.ActorModel
{
    public class ServerActor : ReceiveActor
    {
        private readonly ServerInfoDto _info;

        public ServerActor(ServerInfoDto info)
        {
            _info = info;
        }
    }
}