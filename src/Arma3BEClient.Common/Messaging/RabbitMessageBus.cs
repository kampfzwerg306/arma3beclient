using System;
using EasyNetQ;

namespace Arma3BEClient.Common.Messaging
{
    public class RabbitMessageBus : DisposeObject, IMessageBus
    {
        private IBus _bus;

        public RabbitMessageBus()
        {
            _bus = RabbitHutch.CreateBus("host=netbook;virtualHost=/;username=channelUser;password=12qw!@QW");
        }

        public void PublishMessage<T>(T message) where T : class
        {
            _bus.Publish(message);
        }

        public void SunscribeMessage<T>(string subscriptionId, Action<T> action) where T : class
        {
            _bus.Subscribe(subscriptionId, action);
        }

        protected override void DisposeManagedResources()
        {
            _bus.Dispose();
        }

        protected override void DisposeUnManagedResources()
        {
            
        }
    }
}