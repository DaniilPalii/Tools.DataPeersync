﻿using System;
using Avalonia;
using Avalonia.Logging;
using Avalonia.ReactiveUI;

namespace DataPeersync.Client.Avalonia.Desktop
{
	internal static class Program
	{
		// Initialization code. Don't use any Avalonia, third-party APIs or any
		// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
		// yet and stuff might break.
		[STAThread]
		public static void Main(string[] args)
			=> BuildAvaloniaApp()
				.StartWithClassicDesktopLifetime(args);

		private static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.WithInterFont()
				.LogToTrace(LogEventLevel.Information)
				.UseReactiveUI();
	}
}
