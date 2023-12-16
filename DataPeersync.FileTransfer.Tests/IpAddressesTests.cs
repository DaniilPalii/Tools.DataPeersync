namespace DataPeersync.FileTransfer.Tests
{
	[TestFixture]
	public class IpAddressesTests
	{
		[Test]
		public void GetDefaultGateway_NotNull()
		{
			var ip = IpAddresses.GetDefaultSwitch();

			Assert.That(ip, Is.Not.Null);
			Assert.That(ip?.ToString(), Is.EqualTo("172.29.176.1"));
		}
	}
}
