using System.IO;
using System.Threading.Tasks;
using DataPeersync.FileTransfer;
using ReactiveUI;
using File = DataPeersync.FileTransfer.File;

namespace DataPeersync.Client.MainWindow.FileReceiving
{
	internal class FileReceivingViewModel : ViewModelBase
	{
		public INavigator Navigator { init; get; }

		public int Port { get; }
			= Ports.GetFirstAvailable();

		public string Status
		{
			get => status;
			private set => this.RaiseAndSetIfChanged(ref status, value);
		}

		public async Task Receive()
		{
			Status = "Receiving...";
			ReceivedFile = await receiver.ReceiveAsync(Port);
			Status = $"Received file \"{ReceivedFile.Name}\". Saving...";
			await new FileSaver().SaveAsync(
				Path.Combine(@"D:\Inbox\DataPeersync", ReceivedFile.Name),
				ReceivedFile.ContentBytes);
		}

		private File? ReceivedFile { get; set; }
		
		private string status = string.Empty;
		private readonly FileReceiver receiver = new();
	}
}
