using System.Text;

namespace DataPeersync.FileTransfer
{
	public class File
	{
		public string Name { get; set; }

		public byte[] ContentBytes { get; set; }
		
		public static File FromBytes(byte[] bytes)
		{
			var byteSpan = bytes.AsSpan();
			const int nameStartIndex = sizeof(int);
			var nameBytesLength = BitConverter.ToInt32(byteSpan[..nameStartIndex]);
			var nameEndIndex = nameStartIndex + nameBytesLength;
			
			return new File
			{
				Name = Encoding.ASCII.GetString(
					byteSpan[nameStartIndex..nameEndIndex]),
				
				ContentBytes = byteSpan[nameEndIndex..].ToArray()
			};
		}

		public byte[] ToBytes()
		{
			var bytes = BitConverter.GetBytes(Name.Length).ToList();
			bytes.AddRange(Encoding.ASCII.GetBytes(Name));
			bytes.AddRange(ContentBytes);

			return bytes.ToArray();
		}
	}
}
