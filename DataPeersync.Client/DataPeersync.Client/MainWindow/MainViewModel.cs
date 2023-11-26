using DataPeersync.Client.MainWindow.FileReceiving;
using DataPeersync.Client.MainWindow.FileSending;
using DataPeersync.Client.MainWindow.MainMenu;
using DataPeersync.Client.Services.ServiceProvider;
using ReactiveUI;

namespace DataPeersync.Client.MainWindow
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