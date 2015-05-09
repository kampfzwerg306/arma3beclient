using System.ServiceProcess;

namespace Arma3BEClient.ServiceClient
{
    public class MainService : ServiceBase
    {
        private readonly MainServiceRunner _mainServiceRunner;

        public MainService(MainServiceRunner mainServiceRunner)
        {
            _mainServiceRunner = mainServiceRunner;
            ServiceName = "MainService";
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
