using System.Net.Sockets;

namespace DataPeersync.FileTransfer
{
	public static class Ports
	{
		public static int GetFirstAvailable()
		{
			// Create a new TcpListener instance with a port number of 0,
			// which will allow the operating system to assign an available port.
			var listener = new TcpListener(System.Net.IPAddress.Loopback, port: 0);

			try
			{
				// Start the listener to obtain a port number.
				listener.Start();

				// Get the assigned port number from the listener.
				return ((System.Net.IPEndPoint)listener.LocalEndpoint).Port;
			}
			finally
			{
				// Stop the listener to release the port.
				listener.Stop();
			}
		}
	}
}
