using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using System.Collections.ObjectModel;

namespace MyMauiApp.ViewModels
{
	public class TripViewModel : BaseViewModel<TripRepository, TripModel>
	{
		public TripModel Trip { get; set; } = new();

		private ObservableCollection<TripModel> trips = new();
		public ObservableCollection<TripModel> Trips
		{
			get => trips;
			set => SetProperty(ref trips, value);
		}

		public TripViewModel(TripRepository tripRepository) : base(tripRepository)
		{	
			SaveCommand = new RelayCommand(async () => await Save());
			GetListCommand = new RelayCommand(async () => await GetList());
			DeleteCommand = new RelayCommand<TripModel>(async(trip) => await Delete(trip));
			AddTestDataCommand = new RelayCommand(Repository.SeedData);
			GetList().GetAwaiter();
		}

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

		private async Task GetList()
		{
			Trips = new ObservableCollection<TripModel>(await Repository.GetList());
		}

		private async Task Delete(TripModel trip)
		{
			await Repository.Delete(trip);
			await GetList();
		}
	}
}
