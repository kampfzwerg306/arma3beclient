using System;

namespace Arma3BEClient.ServiceCore.Messages
{
    public class RconServerMessage
    {
        public int Id { get; set; }
        public Guid ServerId { get; set; }
        public string Message { get; set; }

        public string Version { get; set; }
        public string AdditionalData { get; set; }


        public RconServerMessage()
        {
            Version = "0.1.0.0";
        }
    }
}
