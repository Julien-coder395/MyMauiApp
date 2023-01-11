using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	// Classe de base permettant d'utiliser MVVM.
	//internal class BaseViewModel : INotifyPropertyChanged
	//{
	//	public event PropertyChangedEventHandler PropertyChanged;

	//	public void OnPropertyChanged([CallerMemberName] string name = "") =>
	//		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

	//	public string Login { get; set; }
	//}

	public class BaseViewModel<TRepository, TModel> : ObservableObject 
		where TRepository : BaseRepository<TModel>, new()
		where TModel : BaseModel, new()	
	{
		protected TRepository Repository { get; set; }

		public ICommand SaveCommand { get; set; }

		public ICommand DeleteCommand { get; set; }

		public ICommand GetListCommand { get; set; }

		public ICommand AddTestDataCommand { get; set; }

		public BaseViewModel(TRepository repo)
		{
			Repository = repo;
		}
	}
}
