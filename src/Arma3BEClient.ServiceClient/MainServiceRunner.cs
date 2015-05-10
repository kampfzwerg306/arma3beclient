using System;
using Arma3BEClient.Common.Helpers;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.ServiceCore;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;

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
            _log.Info("Starting");
        }

        private BattleEyeClientWrapper _wrapper;

        public void Start()
        {
            _wrapper = new BattleEyeClientWrapper(Guid.NewGuid(), IPHelper.GetIPAddress("server2.tehgam.com"), 2302, "teh123", _log);
            _wrapper.Connect();
        }

        public void Stop()
        {
            
        }        
    }
}