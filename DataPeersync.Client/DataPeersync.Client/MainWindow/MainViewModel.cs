using DataPeersync.Client.MainWindow.FileReceiving;
using DataPeersync.Client.MainWindow.FileSending;
using DataPeersync.Client.MainWindow.MainMenu;
using ReactiveUI;

namespace DataPeersync.Client.MainWindow
{
	public class MainViewModel : ViewModelBase, INavigator
	{
		public MainViewModel()
		{
			GoToMainMenu();
		}
		
		public ViewModelBase Content
		{
			get => content;
			private set => this.RaiseAndSetIfChanged(ref content, value);
		}

		public void GoToFileSending()
		{
			Content = new FileSendingViewModel { Navigator = this };
		}
		
		public void GoToFileReceiving()
		{
			Content = new FileReceivingViewModel { Navigator = this };
		}
		
		public void GoToMainMenu()
		{
			Content = new MainMenuViewModel { Navigator = this };
		}
		
		private ViewModelBase content;
	}
}