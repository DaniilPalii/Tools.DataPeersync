using DataPeersync.Client.Avalonia.Services.FilePickers;

namespace DataPeersync.Client.Avalonia.Services.ServiceProvider
{
	internal class AndroidServiceProvider : IServiceProvider
	{
		public AndroidServiceProvider()
		{
			FilePicker = new AndroidFilePicker();
		}

		public IFilePicker FilePicker { get; }
	}
}
