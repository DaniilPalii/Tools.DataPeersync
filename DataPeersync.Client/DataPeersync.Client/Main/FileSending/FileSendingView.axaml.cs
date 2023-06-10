using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DataPeersync.Client.Main.FileSending
{
	public partial class FileSendingView : UserControl
	{
		public FileSendingView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}

