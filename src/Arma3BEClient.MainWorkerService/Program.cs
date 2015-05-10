using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Arma3BEClient.Common.Logging;

namespace Arma3BEClient.MainWorkerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var log = new Log();
            var mainServiceRunner = new MainWorkerServiceRunner(log);

            if (!Environment.UserInteractive)
                // running as service
                using (var service = new MainWorkerService(mainServiceRunner))
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                try
                {
                    mainServiceRunner.Start();
                    Console.WriteLine("Press any key to stop...");
                    Console.ReadKey(true);
                    mainServiceRunner.Stop();

                }
                catch (Exception e)
                {
                    log.Error(e);
                }
            }
        }
    }
}
