using System.Net;

namespace Arma3BEClient.Common.Helpers
{
    public static class IPHelper
    {public static string GetIPAddress(string host)
        {
            IPAddress ip;

            if (IPAddress.TryParse(host, out ip))
            {
                return ip.ToString();
            }
            try
            {
                var entry = Dns.GetHostEntry(host);
                return entry.AddressList[0].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}