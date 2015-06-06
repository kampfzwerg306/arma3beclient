using System;
using System.Collections.Generic;
using System.ServiceModel.Security.Tokens;
using System.Threading;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Lib.Context;
using Arma3BEService.Lib.Contracts;

namespace Arma3BEService.Core
{
    public class MultiServerWorker
    {
        private readonly ILog _log;

        Dictionary<Guid, Tuple<Thread, ServerWorker>>  _models = new Dictionary<Guid, Tuple<Thread, ServerWorker>>();



        public MultiServerWorker(ILog log)
        {
            _log = log;
        }

        public void Run()
        {
            using (var dc = new Arma3BeServiceContext())
            {
                foreach (var serverInfo in dc.ServerInfo)
                {
                    var model = new ServerWorker(serverInfo, _log);
                    var thread = new Thread(x => { model.Run(); });

                    _models.Add(serverInfo.Id, new Tuple<Thread, ServerWorker>(thread, model));
                    thread.Start();
                }
            }
        }
    }
}