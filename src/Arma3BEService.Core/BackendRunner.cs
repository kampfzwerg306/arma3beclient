using System.ServiceModel;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Service;
using Topshelf;

namespace Arma3BEService.Core
{
    public class BackendRunner : ServiceControl
    {
        private readonly ILog _log;
        private ServiceHost _serviceHost;

        public BackendRunner()
        {
            _log = new Log();
            _serviceHost = new ServiceHost(typeof(Arma3WcfService));
        }
        
        public bool Start(HostControl hostControl)
        {
            _log.Info("start service");
            _serviceHost.Open();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _log.Info("stop service");
            _serviceHost.Close();
            _serviceHost = null;
            return true;
        }
    }
}