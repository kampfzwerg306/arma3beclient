using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using Arma3BEClient.Common.Extensions;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Updater.Models;
using Arma3BEService.Lib.Context;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Service
{
    public class Arma3WcfService : IArma3ServiceContract
    {
        private ILog log = new Log();

        private static List<IArma3ServiceCallbackContract> _callbackList = new List<IArma3ServiceCallbackContract>();

        public ServerBase AddOrUpdateServer(Server server)
        {
            if (server.Id == Guid.Empty)
            {
                server.Id = Guid.NewGuid();

                using (var dc = new Arma3BeServiceContext())
                {
                    var res = dc.ServerInfo.Add(server.Map<ServerInfo>()).Map<ServerBase>();
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
                    return s.Map<ServerBase>();
                }
            }
            
        }

        public ServerBase[] GetServers()
        {
            using (var dc = new Arma3BeServiceContext())
            {
                return dc.ServerInfo.OrderBy(x => x.Name).ToArray().Select(x => x.Map<ServerBase>()).ToArray();
            }
        }

        public void Join()
        {
            IArma3ServiceCallbackContract registeredUser = Callback;

            if (!_callbackList.Contains(registeredUser))
            {
                _callbackList.Add(registeredUser);
            }     
        }

        public int SendChatMessage(ChatMessage message)
        {
            //Callback.Message(message);


            _callbackList.ForEach(
                delegate(IArma3ServiceCallbackContract callback)
                { callback.Message(message); });

            return 0;
        }


        IArma3ServiceCallbackContract Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IArma3ServiceCallbackContract>();
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