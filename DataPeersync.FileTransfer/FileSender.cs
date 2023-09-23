using System.Net;
using System.Net.Sockets;

namespace DataPeersync.FileTransfer
{
	public class FileSender
	{
		public async Task SendAsync(string path, string ipAddress, int port)
		{
			using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			await socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ipAddress), port));

			var file = new File
			{
				Name = Path.GetFileName(path),
				ContentBytes = await System.IO.File.ReadAllBytesAsync(path)
			};
			
			await SendAsync(socket, file.ToBytes());
			socket.Close();
		}

		private static async Task SendAsync(Socket socket, byte[] bytes)
		{
			var bytesLengthBytes = BitConverter.GetBytes(bytes.Length);
			var a = await socket.SendAsync(bytesLengthBytes);
			
			var b = await socket.SendAsync(bytes);
		}
	}
}
