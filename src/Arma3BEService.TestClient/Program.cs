using System;
using Arma3BEService.Lib.Contracts;


namespace Arma3BEService.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new  TestContractClient();

            Console.WriteLine(s.ProcessMessage5("HOHOHO"));


            Console.ReadLine();

            s.Close();
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITestContractChannel : ITestContract, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestContractClient : System.ServiceModel.ClientBase<ITestContract>, ITestContract
    {

        public TestContractClient()
        {
        }

        public TestContractClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public TestContractClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public TestContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public TestContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public string ProcessMessage(string message)
        {
            return base.Channel.ProcessMessage(message);
        }

        public string ProcessMessage5(string message)
        {
            return base.Channel.ProcessMessage5(message);
        }

        public string ProcessMessage2(string message)
        {
            return base.Channel.ProcessMessage2(message);
        }
    }
}
