using System.Threading.Tasks;
using DataPeersync.FileTransfer;
using ReactiveUI;

namespace DataPeersync.Client.MainWindow.FileSending
{
	internal class FileSendingViewModel : ViewModelBase
	{
		public INavigator Navigator { init; get; }
		
		public string? IpAddress { get; set; }
		
		public int? Port { get; set; }
		
		public string? FilePath { get; set; }

		public string Status
		{
			get => status;
			private set => this.RaiseAndSetIfChanged(ref status, value);
		} 

		public async Task Send()
		{
			if (IpAddress is null || Port is null || FilePath is null)
			{
				Status = "Fill all parameters";
				return;
			}

			Status = "Sending..."; 
			await new FileSender().SendAsync(FilePath, IpAddress, Port.Value);
			Status = "Sent";
		}
		
		private string status = string.Empty;
	}
}
 