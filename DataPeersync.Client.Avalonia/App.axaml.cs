using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DataPeersync.Client.Avalonia.MainWindow;
using DataPeersync.Client.Avalonia.Services.ServiceProvider;

namespace DataPeersync.Client.Avalonia
{
	public partial class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			switch (ApplicationLifetime)
			{
				case IClassicDesktopStyleApplicationLifetime desktop:
				{
					var mainWindow = new MainWindow.MainWindow();
					mainWindow.DataContext = new MainViewModel(
						new DesktopServiceProvider(mainWindow.StorageProvider));
					desktop.MainWindow = mainWindow;
					break;
				}
				case ISingleViewApplicationLifetime singleViewPlatform:
				{
					var mainView = new MainView
					{
						DataContext = new MainViewModel(
							new AndroidServiceProvider()),
					};

					singleViewPlatform.MainView = mainView;
					break;
				}
			}

			base.OnFrameworkInitializationCompleted();
		}
	}
}
