using BattleNET;
using System;
using System.Net;
using System.ServiceModel;

namespace Arma3BE.Server.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IClientHost>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/A3BEClient/A3BEClient"));
            var proxy = factory.CreateChannel();








            var proxy2 = new ServiceHostProxy();
            proxy2.ClientHost = proxy;

            using (var host = new ServiceHost(proxy2, new Uri("net.pipe://localhost/A3BEServer")))
            {
                host.AddServiceEndpoint(typeof(IServiceHostProxy), new NetNamedPipeBinding(), "A3BEServer");
                host.Open();

                Console.WriteLine("A3BEServer Service Running...");
                Console.ReadLine();

                host.Close();
            }
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceHostProxy : IServiceHostProxy
    {
        public IClientHost ClientHost;
        private BattlEyeClient _client;

        public ServiceHostProxy()
        {
            //_clientHost = clientHost;
        }

        public int SendCommand(string command)
        {
            return _client?.SendCommand(command) ?? 0;
        }

        public int Connect(string host, int port, string password)
        {
            Disconnect();
            _client = new BattlEyeClient(new BattlEyeLoginCredentials(IPAddress.Parse(host), port, password));
            Subscribe(_client);
            return _client?.Connect() == BattlEyeConnectionResult.Success ? 1 : 0;
        }

        public void Disconnect()
        {
            _client?.Disconnect();
            UnSubscribe(_client);
            _client = null;
        }

        private void Subscribe(BattlEyeClient client)
        {
            if (client == null) return;
            client.BattlEyeConnected += Client_BattlEyeConnected;
            client.BattlEyeDisconnected += Client_BattlEyeDisconnected;
            client.BattlEyeMessageReceived += Client_BattlEyeMessageReceived;
        }

        private void UnSubscribe(BattlEyeClient client)
        {
            if (client == null) return;
            client.BattlEyeConnected -= Client_BattlEyeConnected;
            client.BattlEyeDisconnected -= Client_BattlEyeDisconnected;
            client.BattlEyeMessageReceived -= Client_BattlEyeMessageReceived;
        }


        private void Client_BattlEyeMessageReceived(BattlEyeMessageEventArgs args)
        {
            ClientHost?.MessageRecieved(args.Id, args.Message);
            Console.WriteLine($"Message {args.Id} -- {args.Message}");
        }

        private void Client_BattlEyeDisconnected(BattlEyeDisconnectEventArgs args)
        {
            ClientHost?.Disconnected();
            Console.WriteLine("Disconnected");
        }

        private void Client_BattlEyeConnected(BattlEyeConnectEventArgs args)
        {
            ClientHost?.Connected();
            Console.WriteLine("Connected");
        }
    }

    [ServiceContract]
    public interface IServiceHostProxy
    {
        [OperationContract]
        int SendCommand(string command);

        [OperationContract]
        int Connect(string host, int port, string password);

        [OperationContract]
        void Disconnect();
    }


    [ServiceContract]
    public interface IClientHost
    {
        [OperationContract]
        int MessageRecieved(int id, string message);

        [OperationContract]
        int Connected();

        [OperationContract]
        void Disconnected();
    }





    /*
     
     bool Connected { get; }
        int SendCommand(BattlEyeCommand command, string parameters = "");
        int SendCommand(string command);
        void Disconnect();
        event BattlEyeMessageEventHandler BattlEyeMessageReceived;
        event BattlEyeConnectEventHandler BattlEyeConnected;
        event BattlEyeDisconnectEventHandler BattlEyeDisconnected;
        BattlEyeConnectionResult Connect();
     
     
     */
}