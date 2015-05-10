using System;
using System.Linq;
using EasyNetQ;

namespace Arma3BEClient.Common.Messaging
{
    public interface IMessageBus : IDisposable
    {
        void PublishMessage<T>(T message) where T : class;
        void SunscribeMessage<T>(string subscriptionId, Action<T> action) where T : class;
    }




    public class RabbitMessageBus : DisposeObject, IMessageBus
    {
        private IBus _bus;

        public RabbitMessageBus()
        {
            _bus = RabbitHutch.CreateBus("host=netbook;virtualHost=/;username=tym32167;password=Tym#@167");
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



    public abstract class DisposeObject : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposeObject()
        {
            Dispose(false);
        }


        private bool _disposed;


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Освобождение всех управляемых ресурсов
                //

                DisposeManagedResources();
            }

            // Освобождение неуправляемых ресурсов
            //

            DisposeUnManagedResources();
            _disposed = true;
        }

        protected abstract void DisposeManagedResources();
        protected abstract void DisposeUnManagedResources();
    }
}