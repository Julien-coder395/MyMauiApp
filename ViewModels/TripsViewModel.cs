using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;

namespace MyMauiApp.ViewModels
{
	public class TripViewModel : BaseViewModel<TripRepository, TripModel>
	{
		public TripModel Trip { get; set; } = new();

		public TripViewModel() : base(new TripRepository())
		{
			SaveCommand = new RelayCommand(async () => await Save());
			GetListCommand = new RelayCommand(async () => await GetList());
		}

		private async Task Save()
		{
			if(Trip.Id == 0)
			{
				await Repository.Insert(Trip);
			}
			else
			{
				await Repository.Update(Trip);
			}
		}

		private async Task GetList()
		{
			var trips = await Repository.GetList();
		}
	}
}
