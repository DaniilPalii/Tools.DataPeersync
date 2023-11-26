using Avalonia.Platform.Storage;
using DataPeersync.Client.Services.FilePickers;

namespace DataPeersync.Client.Services.ServiceProvider
{
	internal class DesktopServiceProvider : IServiceProvider
	{
		public DesktopServiceProvider(IStorageProvider storageProvider)
		{
			FilePicker = new DesktopFilePicker(storageProvider);
		}
		
		public IFilePicker FilePicker { get; }
	}
}
