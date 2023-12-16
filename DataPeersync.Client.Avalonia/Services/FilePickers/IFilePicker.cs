using System.Threading.Tasks;

namespace DataPeersync.Client.Avalonia.Services.FilePickers
{
	public interface IFilePicker
	{
		Task<string?> PickAsync();
	}
}
