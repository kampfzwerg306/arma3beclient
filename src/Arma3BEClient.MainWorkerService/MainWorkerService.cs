using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Arma3BEClient.MainWorkerService
{
    public partial class MainWorkerService : ServiceBase
    {
       private readonly MainWorkerServiceRunner _mainServiceRunner;

       public MainWorkerService(MainWorkerServiceRunner mainServiceRunner)
        {
            _mainServiceRunner = mainServiceRunner;
            ServiceName = "MainWorkerService";
        }

        protected override void OnStart(string[] args)
        {
            _mainServiceRunner.Start();
        }

        protected override void OnStop()
        {
            _mainServiceRunner.Stop();
        }
    }
}
