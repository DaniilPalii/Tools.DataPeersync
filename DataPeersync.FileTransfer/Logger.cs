using System.Diagnostics;

namespace DataPeersync.Client.FileTransfer
{
	public static class Logger
	{
		public static void Log(string message)
		{
			Debug.WriteLine(message, category: nameof(FileTransfer));
		}
	}
}
