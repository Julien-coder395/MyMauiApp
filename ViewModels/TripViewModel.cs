using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using System.Collections.ObjectModel;

namespace MyMauiApp.ViewModels
{
	public partial class TripViewModel : BaseViewModel<TripRepository, TripModel>
	{
		[ObservableProperty]
        private TripModel trip = new();

        [ObservableProperty]
        private ObservableCollection<TripModel> trips = new();

        public TripViewModel(TripRepository tripRepository) : base(tripRepository)
		{	
			AddTestDataCommand = new RelayCommand(Repository.SeedData);
			GetList().GetAwaiter();
		}

		[RelayCommand]
		private async Task Save()
		{
			if (Trip.Id == 0)
			{
				await Repository.Insert(Trip);
			}
			else
			{
				await Repository.Update(Trip);
			}
			await GetList();
			Trip = new();
		}

        [RelayCommand]
        private async Task GetList() => Trips = new ObservableCollection<TripModel>(await Repository.GetList());

        [RelayCommand]
        private async Task Delete(TripModel trip)
		{
			await Repository.Delete(trip);
			await GetList();
		}
	}
}
