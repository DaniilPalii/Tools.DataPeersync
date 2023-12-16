using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DataPeersync.FileTransfer
{
	public static class FileSender
	{
		public static async Task SendAsync(string path, IPEndPoint endpoint, TimeSpan timeout, CancellationToken cancellationToken)
		{
			await using var file = new FileStream(path, FileMode.Open);
			var fileName = Path.GetFileName(path);

			using var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			socket.SendTimeout = timeout.Milliseconds;

			try
			{
				await socket.ConnectAsync(endpoint, cancellationToken);

				await SendAsync(fileName, socket, cancellationToken);
				await SendAsync(file, socket, cancellationToken);
			}
			finally
			{
				socket.Shutdown(SocketShutdown.Both);
			}
		}

		private static async Task SendAsync(Stream file, Socket socket, CancellationToken cancellationToken)
		{
			await SendAsync(file.Length, socket, cancellationToken);

			if (file.Length == 0)
				return;

			var buffer = new byte[Configuration.ChunkSize].AsMemory();
			var bytesToSendNumber = file.Length;

			do
			{
				var readBytesNumber = await file.ReadAsync(buffer, cancellationToken);

				if (readBytesNumber == 0)
					throw new Exception($"Error in reading the file. Read {readBytesNumber} bytes but there are {bytesToSendNumber} bytes left to send."); // TODO: create custom exception

				var sentBytesNumber = await socket.SendAsync(buffer[..readBytesNumber], cancellationToken);

				if (sentBytesNumber != readBytesNumber) // TODO: check if "!=" should be changed to "<"
					throw new Exception($"Error in sending the file. Read {readBytesNumber} bytes but sent {sentBytesNumber}."); // TODO: create custom exception

				bytesToSendNumber -= sentBytesNumber;
			}
			while (bytesToSendNumber > 0);
		}

		private static async Task SendAsync(string value, Socket socket, CancellationToken cancellationToken)
		{
			var bytes = Configuration.Encoding.GetBytes(value);
			await SendAsync(bytes.Length, socket, cancellationToken);
			await socket.SendAsync(bytes, cancellationToken);
		}

		private static async Task SendAsync(int value, Socket socket, CancellationToken cancellationToken)
		{
			var bytes = BitConverter.GetBytes(value);
			await socket.SendAsync(bytes, cancellationToken);
		}

		private static async Task SendAsync(long value, Socket socket, CancellationToken cancellationToken)
		{
			var bytes = BitConverter.GetBytes(value);
			await socket.SendAsync(bytes, cancellationToken);
		}
	}
}
