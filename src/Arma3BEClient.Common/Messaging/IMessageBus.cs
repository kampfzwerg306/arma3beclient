using System;
using System.Linq;

namespace Arma3BEClient.Common.Messaging
{
    public interface IMessageBus : IDisposable
    {
        void PublishMessage<T>(T message) where T : class;
        void SunscribeMessage<T>(string subscriptionId, Action<T> action) where T : class;
    }
}