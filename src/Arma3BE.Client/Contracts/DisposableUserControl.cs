﻿using System;
using System.Windows.Controls;

namespace Arma3BEClient.Contracts
{
    public abstract class DisposableUserControl : UserControl, IDisposable
    {
          public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

          ~DisposableUserControl()
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
    }
}