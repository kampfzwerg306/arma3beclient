using System;

namespace Arma3BEClient.Common.Messaging
{
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