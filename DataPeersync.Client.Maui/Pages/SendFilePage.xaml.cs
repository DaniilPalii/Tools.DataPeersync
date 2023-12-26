using System.Net;
using DataPeersync.FileTransfer;

namespace DataPeersync.Client.Maui.Pages
{
	public partial class SendFilePage
	{
		public SendFilePage()
		{
			InitializeComponent();

			IpEntry.TextChanged += (_, args) => ip = args.NewTextValue;
			PortEntry.TextChanged += (_, args) => port = args.NewTextValue;

			BrowseButton.Clicked += async (_, _) => await BrowseFile();
			SendFileButton.Clicked += async (_, _) => await SendFile();
		}

		private async Task BrowseFile()
		{
			var result = await FilePicker.Default.PickAsync();

			if (result != null)
			{
				filePath = result.FullPath;
				FilePathLabel.Text = filePath;
			}
		}

		private async Task SendFile()
		{
			// PermissionStatus statusread = await Permissions.RequestAsync<Permissions.StorageRead>();

			if (!IPAddress.TryParse(ip, out var parsedIp))
			{
				SetStatus("IP is invalid");
				return;
			}

			if (!int.TryParse(port, out var parsedPort))
			{
				SetStatus("Port is invalid");
				return;
			}

			var ipEndPoint = new IPEndPoint(parsedIp, parsedPort);

			var cancellationTokenSource = new CancellationTokenSource();
			Disappearing += (_, _) => cancellationTokenSource.Cancel();

			SetStatus("Sending file...");

			try
			{
				await FileSender.SendAsync(filePath, ipEndPoint, TimeSpan.FromSeconds(30), cancellationTokenSource.Token);
			}
			catch (Exception e)
			{
				SetStatus($"Failed {e.Message}");
			}

			SetStatus("Sent");
		}

		private void SetStatus(string status)
		{
			StatusLabel.Text = status;
		}

		private string ip;
		private string port;
		private string filePath;
	}
}
