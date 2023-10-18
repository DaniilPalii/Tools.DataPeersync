using System.Text;

namespace DataPeersync.FileTransfer
{
	internal static class Configuration
	{
		public const int ChunkSize = 4096;

		public static Encoding Encoding => Encoding.UTF8;
	}
}
