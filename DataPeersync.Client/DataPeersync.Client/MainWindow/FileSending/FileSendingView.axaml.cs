using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DataPeersync.Client.MainWindow.FileSending
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

