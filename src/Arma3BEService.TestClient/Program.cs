using System;
using System.ServiceModel;
using Arma3BEService.Lib.Contracts;
using Arma3BEService.Lib.ModelCompact;
using Arma3BEService.TestClient.ServiceReference1;


namespace Arma3BEService.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var s = new Arma3ServiceContractClient();

            var s = new ServiceReference1.Arma3ServiceContractClient(new InstanceContext(new Callback()));

            var str = string.Empty;

            while ((str = Console.ReadLine()) != "exit")
            {
                //if (s.State == CommunicationState.Faulted)
                //{
                //    //s.Close();
                //    s = new Arma3ServiceContractClient();
                //}

                ////var res = s.AddOrUpdateServer(new Server() { Name = str, Active = true, Host = "host", Password = "pass", Port = 100});
                //s.GetServers();



            }


            Console.ReadLine();

            s.Close();
        }

        public class Callback : ServiceReference1.IArma3ServiceContractCallback
        {
            public void Message(ChatMessage message1)
            {
                Console.WriteLine(message1.Message);
            }
        }

    }


    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    //public interface IArma3ServiceContractChannel : IArma3ServiceContract, System.ServiceModel.IClientChannel
    //{
    //}

    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    //public partial class Arma3ServiceContractClient : System.ServiceModel.ClientBase<IArma3ServiceContract>, IArma3ServiceContract
    //{
    //    public Arma3ServiceContractClient()
    //    {

    //    }

    //    public Arma3ServiceContractClient(string endpointConfigurationName) :
    //        base(endpointConfigurationName)
    //    {
    //    }

    //    public Arma3ServiceContractClient(string endpointConfigurationName, string remoteAddress) :
    //        base(endpointConfigurationName, remoteAddress)
    //    {
    //    }

    //    public Arma3ServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
    //        base(endpointConfigurationName, remoteAddress)
    //    {
    //    }

    //    public Arma3ServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
    //        base(binding, remoteAddress)
    //    {
    //    }

    //    public ServerBase AddOrUpdateServer(Server serverInfo)
    //    {
    //        return base.Channel.AddOrUpdateServer(serverInfo);
    //    }

    //    public ServerBase[] GetServers()
    //    {
    //        return base.Channel.GetServers();
    //    }
    //}
}
