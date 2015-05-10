using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using log4net.Config;

namespace Arma3BEClient.Common.Logging
{

    public class Log : ILog
    {
        private static readonly Lazy<log4net.ILog> Logger = new Lazy<log4net.ILog>(() =>
            log4net.LogManager.GetLogger(typeof(log4net.Repository.Hierarchy.Logger)));

        private static bool _configured;
        private static readonly object Lock = new object();

        private static void Configure()
        {
            if (!_configured)
            {
                lock (Lock)
                {
                    if (!_configured)
                    {
                        XmlConfigurator.Configure();
                        _configured = true;
                    }
                }
            }
        }

        private log4net.ILog _log
        {
            get
            {
                if (!_configured) Configure();
                return Logger.Value;
            }
        }

        private string MemberFormat(
             string memberName = null,
             string sourceFilePath = null,
             int sourceLineNumber = 0,
            object message = null)
        {
            return string.Format("{0}, {1} : {2}\n{3}", memberName, sourceFilePath, sourceLineNumber, message);
        }


        #region Implementation of ILog

        public void Debug(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Debug(m);
        }

        public void Debug(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Debug(m, exception);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0)
        {
            _log.DebugFormat(format, arg0);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.DebugFormat(format, arg0, arg1);
        }
        
        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.DebugFormat(provider, format, args);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Info(m);
        }

        public void Info(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Info(m, exception);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0)
        {
            _log.InfoFormat(format, arg0);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.InfoFormat(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.InfoFormat(provider, format, args);
        }


        public void Warn(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Warn(m);
        }

        public void Warn(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Warn(m, exception);
        }


        [StringFormatMethod("format")]
        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0)
        {
            _log.WarnFormat(format, arg0);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.WarnFormat(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.WarnFormat(provider, format, args);
        }

        public void Error(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Error(m);
        }

        public void Error(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Error(m, exception);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0)
        {
            _log.ErrorFormat(format, arg0);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.ErrorFormat(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.ErrorFormat(provider, format, args);
        }

        public void Fatal(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Fatal(m);
        }

        public void Fatal(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Fatal(m, exception);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0)
        {
            _log.FatalFormat(format, arg0);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.FatalFormat(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.FatalFormat(provider, format, args);
        }

        #endregion
    }
}