using DataPeersync.Client.Services.ServiceProvider;

namespace DataPeersync.Client.MainWindow.MainMenu
{
	internal class MainMenuViewModel : ViewModelBase
	{
		public MainMenuViewModel(IServiceProvider serviceProvider, INavigator navigator) : base(serviceProvider)
		{
			Navigator = navigator;
		}
		
		public INavigator Navigator { get; }
	}
}
