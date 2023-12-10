using DataPeersync.FileTransfer;

namespace DataPeersync.Client.Maui.Pages
{
	public partial class ReceiveFilePage
	{
		public ReceiveFilePage()
		{
			InitializeComponent();

			ObtainPort();
			ReceiveFileButton.Clicked += async (_, _) => await ReceiveFile();
		}

		private async Task ReceiveFile()
		{
			SetStatus("Receiving...");

			try
			{
				var cancellationTokenSource = new CancellationTokenSource();
				var receivedFilePath = await FileReceiver.ReceiveAsync(port, @"D:\Inbox\DataPeersync", cancellationTokenSource.Token);

				SetStatus($"Received {receivedFilePath}");
			}
			catch (Exception exception)
			{
				SetStatus($"Failed. {exception}");
			}
		}

		private void ObtainPort()
		{
			port = Ports.GetFirstAvailable();
			PortLabel.Text = $"Port: {port}";
		}

		private void SetStatus(string status)
		{
			StatusLabel.Text = status;
		}

		private int port;
	}
}

