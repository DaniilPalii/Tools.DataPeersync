using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DataPeersync.Client.MainWindow;
using MainView = DataPeersync.Client.MainWindow.MainView;

namespace DataPeersync.Client
{
	public partial class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				desktop.MainWindow = new MainWindow.MainWindow
				{
					DataContext = new MainViewModel()
				};
			}
			else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
			{
				singleViewPlatform.MainView = new MainView
				{
					DataContext = new MainViewModel()
				};
			}

			base.OnFrameworkInitializationCompleted();
		}
	}
}