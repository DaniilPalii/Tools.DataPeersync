namespace DataPeersync.Client.Maui.Pages
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			SendFileButton.Clicked += async (_, _) => await Navigation.PushAsync(new SendFilePage());
			ReceiveFileButton.Clicked += async (_, _) => await Navigation.PushAsync(new ReceiveFilePage());
		}
	}
}
