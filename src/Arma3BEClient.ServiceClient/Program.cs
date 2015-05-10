using System;
using System.ServiceProcess;
using Arma3BEClient.Common.Logging;
using log4net.Config;

namespace Arma3BEClient.ServiceClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {            
            var log = new Log();
            MainServiceRunner mainServiceRunner = new MainServiceRunner(log);

            if (!Environment.UserInteractive)
                // running as service
                using (var service = new MainService(mainServiceRunner))
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                try
                {
                    mainServiceRunner.Start();
                }
                catch (Exception e)
                {
                    log.Error(e);
                }
                finally
                {
                    Console.WriteLine("Press any key to stop...");
                    Console.ReadKey(true);
                    mainServiceRunner.Stop();
                }
            }
        }
    }
}
