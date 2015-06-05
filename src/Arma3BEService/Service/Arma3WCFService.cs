using System;
using System.Linq;
using Arma3BEClient.Common.Extensions;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Lib.Context;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Service
{
    public class Arma3WcfService : IArma3ServiceContract
    {
        public Server AddOrUpdateServer(Server server)
        {

            if (server.Id == Guid.Empty)
            {
                server.Id = Guid.NewGuid();

                using (var dc = new Arma3BeServiceContext())
                {
                    var res = dc.ServerInfo.Add(server.Map<ServerInfo>()).Map<Server>();
                    dc.SaveChanges();

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

                    return s.Map<Server>();
                }
            }
        }

        public Server[] GetServers()
        {
            using (var dc = new Arma3BeServiceContext())
            {
                return dc.ServerInfo.Cast<Server>().ToArray();
            }
        }
    }
}