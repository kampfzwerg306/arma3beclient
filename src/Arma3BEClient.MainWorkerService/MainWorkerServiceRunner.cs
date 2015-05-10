using System;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Common.Messaging;

namespace Arma3BEClient.MainWorkerService
{
    //[LogException(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    //[Log(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    public class MainWorkerServiceRunner
    {
        private readonly ILog _log;

        public MainWorkerServiceRunner(ILog log)
        {
            _log = log;
            _log.Info("Starting");
        }

        public void Start()
        {

           
        }

        public void Stop()
        {

        }
    }
}