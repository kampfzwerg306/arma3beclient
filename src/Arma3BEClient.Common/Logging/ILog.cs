using System;
using System.Runtime.CompilerServices;

namespace Arma3BEClient.Common.Logging
{
    public interface ILog
    {
        void Debug(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        void Debug(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        void DebugFormat(string format, object arg0);
        void DebugFormat(string format, object arg0, object arg1);
        void DebugFormat(string format, object arg0, object arg1, object arg2);
        void DebugFormat(IFormatProvider provider, string format, params object[] args);

        void Info(string message);

        void Info(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        void Info(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);


        void InfoFormat(string format, params object[] args);
        void InfoFormat(string format, object arg0);
        void InfoFormat(string format, object arg0, object arg1);
        void InfoFormat(string format, object arg0, object arg1, object arg2);
        void InfoFormat(IFormatProvider provider, string format, params object[] args);


        void Warn(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Warn(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);


        void WarnFormat(string format, params object[] args);
        void WarnFormat(string format, object arg0);
        void WarnFormat(string format, object arg0, object arg1);
        void WarnFormat(string format, object arg0, object arg1, object arg2);
        void WarnFormat(IFormatProvider provider, string format, params object[] args);


        void Error(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Error(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(string format, object arg0);
        void ErrorFormat(string format, object arg0, object arg1);
        void ErrorFormat(string format, object arg0, object arg1, object arg2);
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        void Fatal(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Fatal(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        void FatalFormat(string format, params object[] args);
        void FatalFormat(string format, object arg0);
        void FatalFormat(string format, object arg0, object arg1);
        void FatalFormat(string format, object arg0, object arg1, object arg2);
        void FatalFormat(IFormatProvider provider, string format, params object[] args);
    }
}