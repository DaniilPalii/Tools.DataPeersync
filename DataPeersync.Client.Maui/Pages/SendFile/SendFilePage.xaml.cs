namespace DataPeersync.Client.Maui.Pages.SendFile
{
	public partial class SendFilePage
	{
		public SendFilePage()
		{
			InitializeComponent();

			IpEntry.TextChanged += OnIpEntryOnTextChanged;
			PortEntry.TextChanged += (_, args) => port = args.NewTextValue;
		}

		private void OnIpEntryOnTextChanged(object _, TextChangedEventArgs args)
		{
			Ip = args.NewTextValue;
		}

		public string Ip { get; set; }
		private string port;
	}
}

