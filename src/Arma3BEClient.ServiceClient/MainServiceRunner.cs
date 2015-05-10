using System;
using Arma3BEClient.Common.Helpers;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.ServiceCore;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Arma3BEClient.ServiceCore.Context;
using Arma3BEClient.ServiceCore.Model;

namespace Arma3BEClient.ServiceClient
{
    [LogException(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    [Log(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    public class MainServiceRunner
    {
        private readonly ILog _log;
        private readonly Dictionary<Guid, Thread> workers = new Dictionary<Guid, Thread>();
        private readonly Timer _timerCheckThread;

        public MainServiceRunner(ILog log)
        {
            _log = log;
            _log.Info("Starting");
        }

        public void Start()
        {
            _log.Info("Start");

            using (var dc = new Arma3BeClientServiceContext())
            {
                var activeServers = dc.ServerInfo.Where(x => x.Active).ToArray().Select(x=>new BattleEyeClientWrapper(x.Id, IPHelper.GetIPAddress(x.Host), x.Port, x.Password, _log)).ToArray();

                while (true)
                {
                    try
                    {
                        var t = Task.Run(() => Run(activeServers));
                        t.Wait();
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex);
                    }
                }

                GC.KeepAlive(activeServers);
            }
        }


        private static void Run(IEnumerable<BattleEyeClientWrapper> models)
        {
            var creators = models.Select(x => new Func<Thread>(() => new Thread(() => Run(x)) { IsBackground = true })).ToArray();
            var threads = new Thread[creators.Length];

            while (true)
            {
                for (var i = 0; i < threads.Length; i++)
                {
                    var t = threads[i];
                    if (t == null || !t.IsAlive)
                    {
                        if (t != null) t.Abort();
                        var creator = creators[i];
                        t = creator();
                        t.Start();
                    }

                    Thread.Sleep(5000);
                }

                Thread.Sleep(120000);
            }
        }

        private static void Run(BattleEyeClientWrapper model)
        {
            while (true)
            {
                if (!model.Connected)
                {
                    model.Connect();
                }
                Thread.Sleep(123000);
            }
        }

        public void Stop()
        {
            _log.Info("Stop");
        }        
    }
}