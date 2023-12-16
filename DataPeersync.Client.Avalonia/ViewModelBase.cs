using Avalonia.Platform.Storage;
using DataPeersync.Client.Avalonia.Services.ServiceProvider;
using ReactiveUI;

namespace DataPeersync.Client.Avalonia
{
	public abstract class ViewModelBase : ReactiveObject
	{
		protected ViewModelBase(IServiceProvider serviceProvider)
		{
			Services = serviceProvider;
		}

		protected IServiceProvider Services { get; }
	}
}
