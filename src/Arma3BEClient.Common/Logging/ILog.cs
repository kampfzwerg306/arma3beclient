using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

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

        [StringFormatMethod("format")]
        void DebugFormat(string format, object arg0);
        
        [StringFormatMethod("format")]
        void DebugFormat(string format, object arg0, object arg1);

        [StringFormatMethod("format")]
        void DebugFormat(string format, object arg0, object arg1, object arg2);

        [StringFormatMethod("format")]
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

        [StringFormatMethod("format")]
        void InfoFormat(string format, params object[] args);
        [StringFormatMethod("format")]
        void InfoFormat(string format, object arg0);
        [StringFormatMethod("format")]
        void InfoFormat(string format, object arg0, object arg1);
        [StringFormatMethod("format")]
        void InfoFormat(string format, object arg0, object arg1, object arg2);
        [StringFormatMethod("format")]
        void InfoFormat(IFormatProvider provider, string format, params object[] args);


        void Warn(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Warn(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        [StringFormatMethod("format")]
        void WarnFormat(string format, params object[] args);
        [StringFormatMethod("format")]
        void WarnFormat(string format, object arg0);
        [StringFormatMethod("format")]
        void WarnFormat(string format, object arg0, object arg1);
        [StringFormatMethod("format")]
        void WarnFormat(string format, object arg0, object arg1, object arg2);
        [StringFormatMethod("format")]
        void WarnFormat(IFormatProvider provider, string format, params object[] args);


        void Error(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Error(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        [StringFormatMethod("format")]
        void ErrorFormat(string format, params object[] args);
        [StringFormatMethod("format")]
        void ErrorFormat(string format, object arg0);
        [StringFormatMethod("format")]
        void ErrorFormat(string format, object arg0, object arg1);
        [StringFormatMethod("format")]
        void ErrorFormat(string format, object arg0, object arg1, object arg2);
        [StringFormatMethod("format")]
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        void Fatal(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0);

        void Fatal(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0);

        [StringFormatMethod("format")]
        void FatalFormat(string format, params object[] args);
        [StringFormatMethod("format")]
        void FatalFormat(string format, object arg0);
        [StringFormatMethod("format")]
        void FatalFormat(string format, object arg0, object arg1);
        [StringFormatMethod("format")]
        void FatalFormat(string format, object arg0, object arg1, object arg2);
        [StringFormatMethod("format")]
        void FatalFormat(IFormatProvider provider, string format, params object[] args);
    }
}