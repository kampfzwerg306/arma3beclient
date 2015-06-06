using System;
using System.Linq;
using System.Threading;
using Arma3BEClient.Common.Extensions;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Lib.Context;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Service
{
    public class Arma3WcfService : IArma3ServiceContract
    {
        private ILog log = new Log();

        public ServerBase AddOrUpdateServer(Server server)
        {
            if (server.Id == Guid.Empty)
            {
                server.Id = Guid.NewGuid();

                using (var dc = new Arma3BeServiceContext())
                {
                    var res = dc.ServerInfo.Add(server.Map<ServerInfo>()).Map<ServerBase>();
                    dc.SaveChanges();
                    Interrupt();
                    return res;
                }
            }
            else
            {
                using (var dc = new Arma3BeServiceContext())
                {
                    var s = dc.ServerInfo.Single(x => x.Id == server.Id);
                    s.Host = server.Host;
                    s.Name = server.Name;
                    s.Password = server.Password;
                    s.Active = server.Active;
                    s.Port = server.Port;
                    dc.SaveChanges();
                    Interrupt();
                    return s.Map<ServerBase>();
                }
            }
            
        }

        public ServerBase[] GetServers()
        {
            using (var dc = new Arma3BeServiceContext())
            {
                Interrupt();
                return dc.ServerInfo.OrderBy(x => x.Name).ToArray().Select(x => x.Map<ServerBase>()).ToArray();
            }
        }

        private void Interrupt()
        {
            ThreadPool.QueueUserWorkItem((x) =>
            {
                Thread.Sleep(1000);
                log.Debug("interrupting");
                Environment.Exit(1);
            });
        }
    }
}