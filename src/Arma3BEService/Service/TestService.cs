using Arma3BEService.Lib.Contracts;

namespace Arma3BEService.Service
{
    public class TestService : ITestContract
    {
        public string ProcessMessage(string message)
        {
            return string.Format("message {0} processed", message);
        }

        public string ProcessMessage2(string message)
        {
            return string.Format("message 2 {0} processed", message);
        }

        public string ProcessMessage5(string message)
        {
            return "Got it";
        }
    }
}