namespace DataPeersync.Client.Maui.Pages
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void SendFileButton_OnClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SendFilePage());
		}

		private async void ReceiveFileButton_OnClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ReceiveFilePage());
		}
	}
}
