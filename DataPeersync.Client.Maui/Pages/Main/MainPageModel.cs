using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataPeersync.Client.Maui.Pages.ReceiveFile;
using DataPeersync.Client.Maui.Pages.SendFile;

namespace DataPeersync.Client.Maui.Pages.Main
{
	public partial class MainPageModel : ObservableObject
	{
		[RelayCommand]
		public async Task NavigateToSendFilePage()
		{

			await Shell.Current.Navigation.PushAsync(new SendFilePage());
		}

		[RelayCommand]
		private async Task NavigateToReceiveFilePage()
		{
			await Shell.Current.Navigation.PushAsync(new ReceiveFilePage());
		}
	}
}
