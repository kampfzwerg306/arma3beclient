using System.ServiceModel;
using Arma3BEClient.Updater.Models;
using Arma3BEService.Lib.ModelCompact;

namespace Arma3BEService.Lib.Contracts
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Arma3BEService", SessionMode = SessionMode.Required, CallbackContract = typeof(IArma3ServiceCallbackContract))]
    public interface IArma3ServiceContract
    {
        [OperationContract]
        void Join();

        [OperationContract]
        int SendChatMessage(ChatMessage message);

        [OperationContract]
        ServerBase AddOrUpdateServer(Server server);


        [OperationContract]
        ServerBase[] GetServers();
    }

    public interface IArma3ServiceCallbackContract
    {
        [OperationContract(IsOneWay = true)]
        void Message(ChatMessage message);
    }
}