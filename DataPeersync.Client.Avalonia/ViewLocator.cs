using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace DataPeersync.Client.Avalonia
{
	public class ViewLocator : IDataTemplate
	{
		public Control? Build(object? data)
		{
			if (data is null)
				return null;

			var name = data.GetType().FullName!.Replace("ViewModel", "View");
			var type = Type.GetType(name);

			return type != null
				? (Control)Activator.CreateInstance(type)!
				: new TextBlock { Text = name };
		}

		public bool Match(object? data)
		{
			return data is ViewModelBase;
		}
	}
}
