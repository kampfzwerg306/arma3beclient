﻿using System;
using GalaSoft.MvvmLight;

namespace Arma3BEClient.Contracts
{
    public abstract class DisposableViewModelBase : ViewModelBase, IDisposable
    {
         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

         ~DisposableViewModelBase()
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
                DisposeManagedResources();
            }
            DisposeUnManagedResources();
            _disposed = true;
        }

        protected virtual void DisposeManagedResources()
        {
        }

        protected virtual void DisposeUnManagedResources()
        {
        }

        public override void Cleanup()
        {
            base.Cleanup();
            Dispose();
        }
    }
}