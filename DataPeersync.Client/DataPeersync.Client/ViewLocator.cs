using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using DataPeersync.Client.ViewModels;

namespace DataPeersync.Client
{
	public class ViewLocator : IDataTemplate
	{
		public IControl? Build(object? data)
		{
			if (data is null)
				return null;

			var name = data.GetType().FullName!.Replace("ViewModel", "View");
			var type = Type.GetType(name);

			return type != null ? (Control)Activator.CreateInstance(type)! : (IControl)new TextBlock { Text = name };
		}

		public bool Match(object? data)
		{
			return data is ViewModelBase;
		}
	}
}
