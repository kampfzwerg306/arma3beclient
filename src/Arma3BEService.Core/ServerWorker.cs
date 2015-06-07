using System.ServiceModel;
using Arma3BEClient.Common;
using Arma3BEClient.Common.Helpers;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Updater;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Core
{
    public class ServerWorker : DisposeObject
    {
        private readonly ILog _log;
        private readonly UpdateClient _client;

        public ServerWorker(ServerInfo serverInfo, ILog log)
        {
            _log = log;
            var ip = IPHelper.GetIPAddress(serverInfo.Host);
            _client = new UpdateClient(ip, serverInfo.Port, serverInfo.Password, log);


            _client.ChatMessageHandler += _client_ChatMessageHandler;
        }

        void _client_ChatMessageHandler(object sender, Arma3BEClient.Updater.Models.ChatMessage e)
        {
            _log.Info(e.Message);

            //var context = OperationContext.Current.GetCallbackChannel<IArma3ServiceCallbackContract>();
            //context.Message(e);

        }

        public void Run()
        {
            _client.Connect();
        }

        protected override void DisposeManagedResources()
        {
            _client.Dispose();
        }

        protected override void DisposeUnManagedResources()
        {
        }
    }
}