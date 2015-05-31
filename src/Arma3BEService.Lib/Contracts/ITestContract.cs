using System.ServiceModel;

namespace Arma3BEService.Lib.Contracts
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Arma3BEService")]
    public interface ITestContract
    {
        [OperationContract]
        string ProcessMessage(string message);

        [OperationContract]
        string ProcessMessage2(string message);


        [OperationContract]
        string ProcessMessage5(string message);
    }
}