using DataPeersync.Client.Maui.Pages;

namespace DataPeersync.Client.Maui
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(
				new MainPage());
		}

		protected override Window CreateWindow(IActivationState activationState)
		{
			var window = base.CreateWindow(activationState);
			window.Title = "Data Peersync";

			return window;
		}
	}
}
