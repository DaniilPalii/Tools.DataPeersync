using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace DataPeersync.Client.Services.FilePickers
{
	internal class DesktopFilePicker : IFilePicker
	{
		public DesktopFilePicker(IStorageProvider storageProvider)
		{
			this.storageProvider = storageProvider;
		}
		
		public async Task<string?> PickAsync()
		{
			var files = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
			{
				Title = "Pick a file",
				AllowMultiple = false,
			});

			return files.Count == 0
				? null
				: files[0].TryGetLocalPath();
		}
		
		private readonly IStorageProvider storageProvider;
	}
}
