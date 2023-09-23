using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataPeersync.Client.FileTransfer;
using File = DataPeersync.FileTransfer.File;

namespace DataPeersync.FileTransfer
{
	public class FileReceiver
	{
		public async Task<File> ReceiveAsync(int port)
		{
			Logger.Log("Start receiving...");
			
			using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(new IPEndPoint(IPAddress.Any, port));
			socket.Listen(1);
			Logger.Log($"Listening port {port} with socket {socket.Handle}.");

			using var clientSocket = await socket.AcceptAsync();
			Logger.Log($"Accepting connection with socket {clientSocket.Handle}.");

			// var file = new File
			// {
			// 	Name = await ReceiveStringAsync(clientSocket),
			// 	ContentBytes = await ReceiveBytesAsync(clientSocket)
			// };

			var buffer = await ReceiveBytesAsync(clientSocket);
			var file = File.FromBytes(buffer);

			clientSocket.Close();
			socket.Close();
			Logger.Log("Sockets are closed.");
			Logger.Log("Receiving is finished.");

			return file;
		}

		private static async Task<string> ReceiveStringAsync(Socket clientSocket)
		{
			var bytes = await ReceiveBytesAsync(clientSocket);
			
			return Encoding.Unicode.GetString(bytes);
		}
		
		private static async Task<byte[]> ReceiveBytesAsync(Socket clientSocket)
		{
			var bytesNumber = await ReceiveIntAsync(clientSocket);
			Logger.Log($"Received string bytes length: {bytesNumber}.");
			
			var value = await ReceiveBytesAsync(clientSocket, bytesNumber);
			Logger.Log($"Received string: {value}.");
			
			return value;
		}

		private static async Task<int> ReceiveIntAsync(Socket clientSocket)
		{
			var bytes = await ReceiveBytesAsync(clientSocket, bytesNumber: sizeof(int));
			
			return BitConverter.ToInt32(bytes);
		}

		private static async Task<byte[]> ReceiveBytesAsync(Socket clientSocket, int bytesNumber)
		{
			var bytes = new byte[bytesNumber];
			var receivedBytesNumber = await clientSocket.ReceiveAsync(bytes);
			Debug.WriteLine($"Received {receivedBytesNumber} bytes of {bytesNumber}");
			
			return bytes;
		}
	}
}
