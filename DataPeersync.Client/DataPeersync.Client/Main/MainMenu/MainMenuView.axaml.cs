using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DataPeersync.Client.Main.MainMenu
{
	public partial class MainMenuView : UserControl
	{
		public MainMenuView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}

