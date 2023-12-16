using DataPeersync.Client.Avalonia.Services.FilePickers;

namespace DataPeersync.Client.Avalonia.Services.ServiceProvider
{
	public interface IServiceProvider
	{
		IFilePicker FilePicker { get; }
	}
}
