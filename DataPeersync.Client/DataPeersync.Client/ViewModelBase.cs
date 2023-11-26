using Avalonia.Platform.Storage;
using DataPeersync.Client.Services.ServiceProvider;
using ReactiveUI;

namespace DataPeersync.Client
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