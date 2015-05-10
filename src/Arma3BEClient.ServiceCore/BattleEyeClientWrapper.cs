using System;
using System.Net;
using Arma3BEClient.Common.Logging;
using Arma3BEClient.Common.Messaging;
using Arma3BEClient.ServiceCore.Messages;
using BattleNET;

namespace Arma3BEClient.ServiceCore
{
    public class BattleEyeClientWrapper : DisposeObject
    {
        private readonly Guid _serverId;
        private readonly string _host;
        private readonly int _port;
        private readonly string _password;
        private readonly ILog _log;
        private BattlEyeClient _battlEyeClient;

        private RabbitMessageBus _bus;
        

        private object _lock = new object();



        public BattleEyeClientWrapper(Guid serverId, string host, int port, string password, ILog log)
        {
            _serverId = serverId;
            _host = host;
            _port = port;
            _password = password;
            _log = log;

            InitClients();
            InitBus();
        }


        void battlEyeClient_BattlEyeMessageReceived(BattlEyeMessageEventArgs args)
        {
            try
            {
                var message = new RconServerMessage(){Id = args.Id, Message = args.Message, ServerId = _serverId};

                lock (_lock)
                {
                    ProcessMessage(message);
                }

            }
            catch (Exception e)
            {
                _log.Error(e);
            }

        }


        public bool Connected { get { return _battlEyeClient != null && _battlEyeClient.Connected; } }


        private void ProcessMessage(RconServerMessage message)
        {
            RegisterMessage(message);
        }


        private void RegisterMessage(RconServerMessage message)
        {
            _bus.PublishMessage(message);
        }

        public void Connect()
        {
            _log.Info(string.Format("{0}:{1} Update client - connect", _host, _port));

            InitClients();

            if (_battlEyeClient != null && !_battlEyeClient.Connected)
            {
                
                    _battlEyeClient.Connect();
            }
        }


        private void InitBus()
        {
            _log.Info(string.Format("{0}:{1} Update client - InitBus", _host, _port));
            lock (_lock)
            {
                if (_bus != null) ReleaseBus();
                _bus = new RabbitMessageBus();
            }
        }

        private void InitClients()
        {
            _log.Info(string.Format("{0}:{1} Update client - InitClients", _host, _port));
            lock (_lock)
            {
                if (_battlEyeClient != null) ReleaseClient();

                var credentials = new BattlEyeLoginCredentials(IPAddress.Parse(_host), _port, _password);
                _battlEyeClient = new BattlEyeClient(credentials);
                _battlEyeClient.ReconnectOnPacketLoss = true;
                _battlEyeClient.BattlEyeMessageReceived += battlEyeClient_BattlEyeMessageReceived;
            }
        }


        private void ReleaseClient()
        {
            _log.Info(string.Format("{0}:{1} Update client - ReleaseClient", _host, _port));
            lock (_lock)
            {
                if (_battlEyeClient != null)
                {
                    try
                    {
                        if (_battlEyeClient.Connected) _battlEyeClient.Disconnect();
                        _battlEyeClient.BattlEyeMessageReceived -= battlEyeClient_BattlEyeMessageReceived;
                    }
                    finally
                    {
                        _battlEyeClient = null;
                    }
                }
            }
        }

        private void ReleaseBus()
        {
            _log.Info(string.Format("{0}:{1} Update client - ReleaseBus", _host, _port));
            lock (_lock)
            {
                if (_bus != null)
                {
                    _bus.Dispose();
                    _bus = null;
                }
            }
        }

        public void Disconnect()
        {
            _log.Info(string.Format("{0}:{1} Update client - Disconnect", _host, _port));
            try
            {
                ReleaseClient();
                ReleaseBus();
            }
            catch
            {
            }
        }

        protected override void DisposeUnManagedResources()
        {

        }


        protected override void DisposeManagedResources()
        {
            try
            {
                ReleaseClient();
                ReleaseBus();

                GC.SuppressFinalize(this);
            }
            finally
            {
                _battlEyeClient = null;
            }
        }
    }
}
