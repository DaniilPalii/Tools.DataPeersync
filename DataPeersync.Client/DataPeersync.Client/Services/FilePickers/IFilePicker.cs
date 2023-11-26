using System.Threading.Tasks;

namespace DataPeersync.Client.Services.FilePickers
{
	public interface IFilePicker
	{
		Task<string?> PickAsync();
	}
}
