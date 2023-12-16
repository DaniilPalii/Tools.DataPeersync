using DataPeersync.Client.Avalonia.MainWindow.FileReceiving;
using DataPeersync.Client.Avalonia.MainWindow.FileSending;
using DataPeersync.Client.Avalonia.MainWindow.MainMenu;
using DataPeersync.Client.Avalonia.Services.ServiceProvider;
using ReactiveUI;

namespace DataPeersync.Client.Avalonia.MainWindow
{
	public class MainViewModel : ViewModelBase, INavigator
	{
		public MainViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			GoToMainMenu();
		}

		public ViewModelBase? Content
		{
			get => content;
			private set => this.RaiseAndSetIfChanged(ref content, value);
		}

		public void GoToFileSending()
		{
			Content = new FileSendingViewModel(Services, navigator: this);
		}

		public void GoToFileReceiving()
		{
			Content = new FileReceivingViewModel(Services, navigator: this);
		}

		public void GoToMainMenu()
		{
			Content = new MainMenuViewModel(Services, navigator: this);
		}

		private ViewModelBase? content;
	}
}
