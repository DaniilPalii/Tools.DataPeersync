using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace DataPeersync.FileTransfer
{
	public static class IpAddresses
	{
		public static IPAddress? GetDefaultSwitch()
		{
			return NetworkInterface
				.GetAllNetworkInterfaces()
				.Where(n => n.OperationalStatus == OperationalStatus.Up)
				.Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				.SelectMany(n => n.GetIPProperties().UnicastAddresses)
				.Where(ua => ua.Address.AddressFamily == AddressFamily.InterNetwork) // IP v4
				.Select(ua => ua.Address)
				.LastOrDefault(); // TODO improve
		}
	}
}
