using DataPeersync.Client.Main.FileReceiving;
using DataPeersync.Client.Main.FileSending;
using DataPeersync.Client.Main.MainMenu;
using ReactiveUI;

namespace DataPeersync.Client.Main
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