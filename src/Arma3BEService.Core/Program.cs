using System;
using Topshelf;

namespace Arma3BEService.Core
{
    static class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<BackendRunner>();
                x.RunAsLocalSystem();
                x.StartAutomatically();
                
                x.SetDescription("Arma3BEService");
                x.SetDisplayName("Arma3BEService");
                x.SetServiceName("Arma3BEService");
            });
        }
    }
}
