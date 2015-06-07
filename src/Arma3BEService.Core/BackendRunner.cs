using System.ServiceModel;
using System.Threading;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Service;
using Topshelf;

namespace Arma3BEService.Core
{
    public class BackendRunner : ServiceControl
    {
        private readonly ILog _log;
        private ServiceHost _serviceHost;
        private Thread workerThread;

        public BackendRunner()
        {
            _log = new Log();
            _serviceHost = new ServiceHost(typeof(Arma3WcfService));
        }
        
        public bool Start(HostControl hostControl)
        {
            _log.Info("start service");
            _serviceHost.Open();
           
            //var context = OperationContext.Current.GetCallbackChannel<IArma3ServiceCallbackContract>();
            
            workerThread = new Thread(x => { new MultiServerWorker(_log).Run(); });
            workerThread.Start();
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