using DataPeersync.FileTransfer;

namespace DataPeersync.Client.Maui.Pages
{
	public partial class ReceiveFilePage
	{
		public ReceiveFilePage()
		{
			InitializeComponent();

			ReceiveFileButton.Clicked += async (_, _) => await ReceiveFile();

			ObtainIp();
			ObtainPort();
		}

		private async Task ReceiveFile()
		{
			SetStatus("Receiving...");

			try
			{
				var cancellationTokenSource = new CancellationTokenSource();
				Disappearing += (_, _) => cancellationTokenSource.Cancel();

				var receivedFilePath = await FileReceiver.ReceiveAsync(port, @"D:\Inbox\DataPeersync", cancellationTokenSource.Token);

				SetStatus($"Received {receivedFilePath}");
			}
			catch (Exception exception)
			{
				SetStatus($"Failed. {exception}");
			}
		}

		private void ObtainIp()
		{
			IpLabel.Text = IpAddresses.GetDefaultSwitch()?.ToString()
				?? "No IP";
		}

		private void ObtainPort()
		{
			port = Ports.GetFirstAvailable();
			PortLabel.Text = port.ToString();
		}

		private void SetStatus(string status)
		{
			StatusLabel.Text = status;
		}

		private int port;
	}
}
