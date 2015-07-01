using System;
using System.ServiceModel;
using System.Threading;
using Arma3BEClient.Common;
using Arma3BEClient.Common.Helpers;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Updater;
using Arma3BEClient.Updater.Models;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Core
{
    public class ServerWorker : DisposeObject
    {
        private readonly ILog _log;
        private readonly UpdateClient _client;

      //  private readonly SelfServiceReference.Arma3ServiceContractClient Arma3ServiceContractClient = new Arma3ServiceContractClient(new InstanceContext(new Callback()));

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

          //  if (Arma3ServiceContractClient.State == CommunicationState.Faulted) return;
          //  Arma3ServiceContractClient.SendChatMessage(e);
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


        //public class Callback : SelfServiceReference.IArma3ServiceContractCallback
        //{
        //    public void Message(ChatMessage message1)
        //    {
        //    }
        //}
    }
}