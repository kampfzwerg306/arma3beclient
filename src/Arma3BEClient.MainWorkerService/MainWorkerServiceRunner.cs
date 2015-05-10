using System;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Common.Messaging;
using Arma3BEClient.ServiceCore.Messages;

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

        RabbitMessageBus _bus = new RabbitMessageBus();

        public void Start()
        {
            _bus.SunscribeMessage<RconServerMessage>("ServerMessage", x => System.Console.WriteLine(x.Message));
        }

        public void Stop()
        {

        }
    }
}