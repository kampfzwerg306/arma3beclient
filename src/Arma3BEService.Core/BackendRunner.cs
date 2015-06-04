using System;
using System.ServiceModel;
using Arma3BEService.Service;
using Topshelf;

namespace Arma3BEService.Core
{
    public class BackendRunner : ServiceControl
    {
        private ServiceHost serviceHost;

        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("start");
            serviceHost = new ServiceHost(typeof(TestService));
            serviceHost.Open();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("stop");
            serviceHost.Close();
            serviceHost = null;
            return true;
        }
    }
}