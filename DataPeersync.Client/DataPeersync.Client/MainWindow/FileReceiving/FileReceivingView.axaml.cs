using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DataPeersync.Client.MainWindow.FileReceiving
{
	public partial class FileReceivingView : UserControl
	{
		public FileReceivingView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}

