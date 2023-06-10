namespace DataPeersync.Client
{
	internal interface INavigator
	{
		public void GoToFileSending();

		public void GoToFileReceiving();

		public void GoToMainMenu();
	}
}
