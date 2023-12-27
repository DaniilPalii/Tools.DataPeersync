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
				var receivedFilePath = await FileReceiver.ReceiveAsync(
					port,
					@"D:\Inbox\DataPeersync",
					GetCancellationToken());

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

		private CancellationToken GetCancellationToken()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			Disappearing += (_, _) => cancellationTokenSource.Cancel();

			return cancellationTokenSource.Token;
		}

		private int port;
	}
}
