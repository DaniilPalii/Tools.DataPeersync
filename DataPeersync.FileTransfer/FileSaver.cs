using DataPeersync.Client.FileTransfer;

namespace DataPeersync.FileTransfer;

public class FileSaver
{
	public async Task SaveAsync(string path, byte[] bytes)
	{
		Logger.Log($"Saving file to {path}");
		await using var fileStream = new FileStream(path, FileMode.Create);
		await fileStream.WriteAsync(bytes);
		Logger.Log($"Saved file to {path}");
	}
}