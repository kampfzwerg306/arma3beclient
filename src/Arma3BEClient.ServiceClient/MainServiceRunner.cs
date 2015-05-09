using System;
using log4net;
using log4net.Config;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;
using ILog = Arma3BEClient.Common.Logging.ILog;

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
        }

        public void Start()
        {
            throw new Exception("asd");
        }

        public void Stop()
        {
            
        }
    }
}