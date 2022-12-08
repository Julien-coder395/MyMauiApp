using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	public class MainViewModel5 : ObservableObject
	{
		private string name;

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		private bool isVisible = true;
		public bool IsVisible
		{
			get => isVisible;
			set => SetProperty(ref isVisible, value);
		}

		public ICommand ShowHideMessageCommand { get; }

		public MainViewModel5()
		{
			name = "Hello World CommunityToolkitMVVM";
			ShowHideMessageCommand = new RelayCommand(ShowHideMessage);
		}

		private void ShowHideMessage()
		{
			IsVisible = !IsVisible;
		}
	}
}
