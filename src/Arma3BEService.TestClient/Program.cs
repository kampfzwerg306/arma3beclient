using System;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;


namespace Arma3BEService.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new  Arma3ServiceContractClient();

            var str = string.Empty;

            while ((str = Console.ReadLine())!="exit")
            {
                var res = s.AddOrUpdateServer(new Server() { Name = str, Active = true, Host = "host", Password = "pass", Port = 100});

            }


            Console.ReadLine();

            s.Close();
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IArma3ServiceContractChannel : IArma3ServiceContract, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Arma3ServiceContractClient : System.ServiceModel.ClientBase<IArma3ServiceContract>, IArma3ServiceContract
    {

        public Arma3ServiceContractClient()
        {
        }

        public Arma3ServiceContractClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public Arma3ServiceContractClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public Arma3ServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public Arma3ServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Server AddOrUpdateServer(Server serverInfo)
        {
            return base.Channel.AddOrUpdateServer(serverInfo);
        }

        public Server[] GetServers()
        {
            return base.Channel.GetServers();
        }
    }
}
