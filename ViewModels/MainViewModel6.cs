using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	internal class MainViewModel6 : ObservableObject
	{ 
		// Ne pas oublier {get; set;}, sinon Binding ne fonctionne pas. 
		public ObservableCollection<UserModel> Users { get; set; } = new();
		
		public ICommand GetUsersCommand { get; set; }

		public MainViewModel6()
		{
			GetUsersCommand = new RelayCommand(GetUsers);	
		}

		private void GetUsers()
		{
			Users.Add(new UserModel { Login = "Guillaume", Password = "1234" });
			Users.Add(new UserModel { Login = "Julien", Password = "4321" });
		}
	}
}
