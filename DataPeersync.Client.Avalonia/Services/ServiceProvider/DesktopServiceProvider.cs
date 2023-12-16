using Avalonia.Platform.Storage;
using DataPeersync.Client.Avalonia.Services.FilePickers;

namespace DataPeersync.Client.Avalonia.Services.ServiceProvider
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
