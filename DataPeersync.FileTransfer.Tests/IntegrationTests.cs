using System.Net;

namespace DataPeersync.FileTransfer.Tests
{
	[TestFixture]
	internal class IntegrationTests
	{
		[SetUp]
		public async Task Setup()
		{
			Directory.CreateDirectory(TemporaryTestDirectory);
			Directory.CreateDirectory(SampleDirectoryPath);
			Directory.CreateDirectory(ReceivedDirectoryPath);
			await File.WriteAllTextAsync(path: SampleFilePath, contents: SampleFileContent);
		}

		[TearDown]
		public void TearDown()
		{
			Directory.Delete(TemporaryTestDirectory, recursive: true);
		}
		
		[Test]
		public async Task Test()
		{
			var port = Ports.GetFirstAvailable();
			var cancellationTokenSource = new CancellationTokenSource();

			async Task SendFileAsync()
			{
				await FileSender.SendAsync(
					SampleFilePath,
					new IPEndPoint(IPAddress.Parse("127.0.0.1"), port),
					timeout: TimeSpan.FromSeconds(10),
					cancellationTokenSource.Token);
			}
			var receivedFilePath = string.Empty;
			async Task ReceiveFileAsync()
			{
				receivedFilePath = await FileReceiver.ReceiveAsync(port, ReceivedDirectoryPath, cancellationTokenSource.Token);
			}
			await Task.WhenAll(SendFileAsync(), ReceiveFileAsync());

			var originalContent = await File.ReadAllTextAsync(SampleFilePath);
			var receivedContent = await File.ReadAllTextAsync(receivedFilePath);
			Assert.That(receivedContent, Is.EqualTo(originalContent));
		}
	
		private const string TemporaryTestDirectory = "TestTemp";
		private const string SampleDirectoryPath = $"{TemporaryTestDirectory}/Samples";
		private const string ReceivedDirectoryPath = $"{TemporaryTestDirectory}/Received";
		private const string SampleFileName = "SampleFile.txt";
		private const string SampleFilePath = $"{SampleDirectoryPath}/{SampleFileName}";
		private const string SampleFileContent = "This is sample file.\n\rIt has 2 lines.";
	}
}
