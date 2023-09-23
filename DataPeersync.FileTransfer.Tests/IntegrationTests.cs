namespace DataPeersync.FileTransfer.Tests
{
	[TestFixture]
	internal class IntegrationTests
	{
		[Test]
		public async Task Test()
		{
			var port = Ports.GetFirstAvailable();

			await Task.WhenAll(
				SendAsync(port),
				ReceiveAsync(port));

			var originalContent = await System.IO.File.ReadAllTextAsync(@"D:\Inbox\test.txt");
			var receivedContent = await System.IO.File.ReadAllTextAsync(@"D:\Inbox\DataPeersync\test.txt");
			
			Assert.That(originalContent, Is.EqualTo(receivedContent));
		}

		private static async Task ReceiveAsync(int port)
		{
			var fileReceiver = new FileReceiver();
			var file = await fileReceiver.ReceiveAsync(port);
			
			var fileSaver = new FileSaver();
			await fileSaver.SaveAsync(@"D:\Inbox\DataPeersync\test.txt", file.ContentBytes);
		}

		private static async Task SendAsync(int port)
		{
			var fileSender = new FileSender();
			await fileSender.SendAsync(@"D:\Inbox\test.txt", "127.0.0.1", port);
		}
	}
}
