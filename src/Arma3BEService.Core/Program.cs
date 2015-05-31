using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Arma3BEClient.Common.Logging;
using Arma3BEService.Service;

namespace Arma3BEService.Core
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            var serviceHost = new ServiceHost(typeof(TestService));

            serviceHost.Open();


            while (Console.ReadLine() != "exit") ;

            serviceHost.Close();
            serviceHost = null;

            //var log = new Log();
            //MainServiceRunner mainServiceRunner = new MainServiceRunner(log);

            //if (!Environment.UserInteractive)
            //    // running as service
            //    using (var service = new MainService(mainServiceRunner))
            //        ServiceBase.Run(service);
            //else
            //{
            //    // running as console app
            //    try
            //    {
            //        mainServiceRunner.Start();
            //    }
            //    catch (Exception e)
            //    {
            //        log.Error(e);
            //    }
            //    finally
            //    {
            //        Console.WriteLine("Press any key to stop...");
            //        Console.ReadKey(true);
            //        mainServiceRunner.Stop();
            //    }
            //}



        }
    }
}
