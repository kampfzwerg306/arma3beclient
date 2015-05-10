using System;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Common.Messaging;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;

namespace Arma3BEClient.ServiceClient
{
    [LogException(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    [Log(AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Public)]
    public class MainServiceRunner
    {
        private readonly ILog _log;

        public MainServiceRunner(ILog log)
        {
            _log = log;
            _log.Info("Starting");
        }

        private RabbitMessageBus bus = new RabbitMessageBus();

        public void Start()
        {

            //bus.SunscribeMessage<MyMessage>(m => Console.WriteLine(m.Text));

            //using ()
            {
                Console.WriteLine("Send 1");
                bus.PublishMessage(new MyMessage());
                Console.WriteLine("Send 2");
                bus.PublishMessage(new MyMessage());
                Console.WriteLine("Send 3");
                bus.PublishMessage(new MyMessage());
                Console.WriteLine("end send");
            }
        }

        public void Stop()
        {
            
        }

        public class MyMessage
        {
            public Guid Id { get; set; }
            public string Text { get; set; }

            public MyMessage()
            {
                Id = Guid.NewGuid();
                Text = Id.ToString();
            }
        }
    }
}