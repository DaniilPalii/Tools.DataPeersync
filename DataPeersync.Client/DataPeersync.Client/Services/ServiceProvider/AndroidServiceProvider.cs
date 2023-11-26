using DataPeersync.Client.Services.FilePickers;

namespace DataPeersync.Client.Services.ServiceProvider
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
