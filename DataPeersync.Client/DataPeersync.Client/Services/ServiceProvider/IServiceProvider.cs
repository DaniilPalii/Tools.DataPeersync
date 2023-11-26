using DataPeersync.Client.Services.FilePickers;

namespace DataPeersync.Client.Services.ServiceProvider
{
	public interface IServiceProvider
	{
		IFilePicker FilePicker { get; }
	}
}
