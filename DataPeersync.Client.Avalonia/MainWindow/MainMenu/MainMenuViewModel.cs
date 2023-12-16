using DataPeersync.Client.Avalonia.Services.ServiceProvider;

namespace DataPeersync.Client.Avalonia.MainWindow.MainMenu
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
