using Arma3BEClient.Common;
using Arma3BEClient.Common.Helpers;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Updater;

namespace Arma3BEService.Core
{
    public class ServerWorker : DisposeObject
    {
        private readonly ILog _log;
        private readonly UpdateClient _client;

        public ServerWorker(string host, int port, string password, ILog log)
        {
            _log = log;
            var ip = IPHelper.GetIPAddress(host);
            _client = new UpdateClient(ip, port, password, log);
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