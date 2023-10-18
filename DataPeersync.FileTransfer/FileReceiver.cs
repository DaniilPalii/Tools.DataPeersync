using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DataPeersync.FileTransfer
{
	public static class FileReceiver
	{
		public static async Task<string> ReceiveAsync(int port, string directoryPath, CancellationToken cancellationToken)
		{
			using var listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			listeningSocket.Bind(new IPEndPoint(IPAddress.Any, port));
			listeningSocket.Listen(backlog: 1);

			using var clientSocket = await listeningSocket.AcceptAsync(cancellationToken);
			// TODO: Test closing of listeningSocket here

			var fileName = await ReceiveStringAsync(clientSocket, cancellationToken);
			var receivedFilePath = await ReceiveFileAsync(clientSocket, fileName, directoryPath, cancellationToken);

			// TODO: check if socket shutdown required

			return receivedFilePath;
		}

		private static async Task<string> ReceiveFileAsync(Socket socket, string name, string directoryPath, CancellationToken cancellationToken)
		{
			var filePath = Path.Combine(directoryPath, name);
			await using var file = new FileStream(filePath, FileMode.Create);

			var fileSizeInBytes = await ReceiveLongAsync(socket, cancellationToken);

			if (fileSizeInBytes == 0)
				return filePath;

			var buffer = new byte[Configuration.ChunkSize].AsMemory();
			var bytesToReceiveNumber = fileSizeInBytes;
			
			do
			{
				var receivedBytesNumber = await socket.ReceiveAsync(buffer, cancellationToken);
				await file.WriteAsync(buffer[..receivedBytesNumber], cancellationToken);
				bytesToReceiveNumber -= receivedBytesNumber;
			}
			while (bytesToReceiveNumber > 0);

			// TODO: check if flush required

			return filePath;
		}

		private static async Task<string> ReceiveStringAsync(Socket socket, CancellationToken cancellationToken)
		{
			var bytes = await ReceiveBytesAsync(socket, cancellationToken);
			
			return Encoding.UTF8.GetString(bytes);
		}
		
		private static async Task<byte[]> ReceiveBytesAsync(Socket socket, CancellationToken cancellationToken)
		{
			var bytesNumber = await ReceiveIntAsync(socket, cancellationToken);
		
			return await ReceiveBytesAsync(socket, bytesNumber, cancellationToken);
		}

		private static async Task<int> ReceiveIntAsync(Socket clientSocket, CancellationToken cancellationToken)
		{
			var bytes = await ReceiveBytesAsync(clientSocket, bytesNumber: sizeof(int), cancellationToken);
			
			return BitConverter.ToInt32(bytes);
		}

		private static async Task<long> ReceiveLongAsync(Socket socket, CancellationToken cancellationToken)
		{
			var bytes = await ReceiveBytesAsync(socket, bytesNumber: sizeof(long), cancellationToken);
			
			return BitConverter.ToInt64(bytes);
		}

		private static async Task<byte[]> ReceiveBytesAsync(Socket socket, int bytesNumber, CancellationToken cancellationToken)
		{
			var bytes = new byte[bytesNumber];
			await socket.ReceiveAsync(bytes, cancellationToken);
			
			return bytes;
		}
	}
}
