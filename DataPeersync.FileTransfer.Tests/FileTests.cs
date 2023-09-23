namespace DataPeersync.FileTransfer.Tests;

public class FileTests
{
	[SetUp]
	public void Setup()
	{
		CreateSampleFile();
	}

	[Test]
	public async Task FromBytes_ShouldCreateFile()
	{
		var fileContentBytes = await System.IO.File.ReadAllBytesAsync(SampleFilePath);
		file = new File
		{
			Name = SampleFileName,
			ContentBytes = fileContentBytes,
		};

		var bytes = file.ToBytes();
		var convertedFile = File.FromBytes(bytes);
		
		Assert.Multiple(() =>
		{
			Assert.That(file.Name, Is.EqualTo(convertedFile.Name));
			Assert.That(file.ContentBytes, Is.EquivalentTo(convertedFile.ContentBytes));
		});
	}

	[TearDown]
	public void TearDown()
	{
		RemoveSamples();
	}

	private static async void CreateSampleFile()
	{
		Directory.CreateDirectory(SampleDirectoryPath);
		await System.IO.File.WriteAllTextAsync(path: SampleFilePath, contents: SampleFileContent);
	}

	private static void RemoveSamples()
	{
		Directory.Delete(SampleDirectoryPath, recursive: true);
	}

	private static File file;
	
	private const string SampleDirectoryPath = "TestSamples";

	private const string SampleFileName = "SampleFile.txt";
	private static readonly string SampleFilePath = Path.Combine(SampleDirectoryPath, SampleFileName);
	private static readonly string SampleFileContent = $"This is sample file.{Environment.NewLine}It has 2 lines.";

	private const string CopiedFileName = "CopiedSampleFile.txt";
	private static readonly string CopiedFilePath = Path.Combine(SampleDirectoryPath, CopiedFileName);
}
