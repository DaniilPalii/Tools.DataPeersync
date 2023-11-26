using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataPeersync.FileTransfer;
using ReactiveUI;
using Xamarin.Essentials;
using IServiceProvider = DataPeersync.Client.Services.ServiceProvider.IServiceProvider;

namespace DataPeersync.Client.MainWindow.FileSending
{
	internal class FileSendingViewModel : ViewModelBase
	{
		public FileSendingViewModel(IServiceProvider serviceProvider, INavigator navigator) : base(serviceProvider)
		{
			this.navigator = navigator;
		}
		
		public string? IpString { get; set; }
		
		public int? Port { get; set; }

		public string? FilePath { get; set; }

		public string Status
		{
			get => status;
			private set => this.RaiseAndSetIfChanged(ref status, value);
		}

		public async Task Send()
		{
			if (IpString is null || Port is null || FilePath is null)
			{
				Status = "Fill all parameters";
				return;
			}

			var isIpValid = IPAddress.TryParse(IpString, out var ip);

			if (!isIpValid)
			{
				Status = "IP is invalid";
				return;
			}
			
			Status = "Sending...";

			var cancellationTokenSource = new CancellationTokenSource();
			OnExit += () => cancellationTokenSource.Cancel();

			try
			{
				await FileSender.SendAsync(
					FilePath,
					new IPEndPoint(ip!, Port.Value),
					timeout: TimeSpan.FromMinutes(10),
					cancellationTokenSource.Token);
				
				Status = "Sent";
			}
			catch (Exception exception)
			{
				Status = $"Failed. {exception}";
			}
		}
	
		public void GoToMainMenu()
		{
			OnExit?.Invoke();
			navigator.GoToMainMenu();
		}

		public async void BrowseFile()
		{
			var file = await FilePicker.PickAsync();
			FilePath = file?.FileName;
			this.RaisePropertyChanged(nameof(FilePath));
		}

		private event Action? OnExit;
		
		private string status = string.Empty;

		private readonly INavigator navigator;
	}
}
 