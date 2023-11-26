using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DataPeersync.Client.Services.FilePickers
{
	internal class AndroidFilePicker : IFilePicker
	{
		public async Task<string?> PickAsync()
		{
			var file = await FilePicker.PickAsync();

			return file?.FullPath;
		}
	}
}
