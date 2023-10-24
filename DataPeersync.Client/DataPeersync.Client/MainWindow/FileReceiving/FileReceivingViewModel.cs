using System;
using System.Threading;
using System.Threading.Tasks;
using DataPeersync.FileTransfer;
using ReactiveUI;

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

			try
			{
				var cancellationTokenSource = new CancellationTokenSource();
				var receivedFilePath = await FileReceiver.ReceiveAsync(Port, @"D:\Inbox\DataPeersync", cancellationTokenSource.Token);

				Status = $"Received {receivedFilePath}";
			}
			catch (Exception exception)
			{
				Status = $"Failed. {exception}";
			}
		}
		
		private string status = string.Empty;
	}
}
