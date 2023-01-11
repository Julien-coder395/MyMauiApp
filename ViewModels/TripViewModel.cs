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

		public TripViewModel() : base(new TripRepository())
		{
			// Ajout des données en dur (n'est plus utilisé)
			//var trip1 = new TripModel() { Date = DateTime.Now, Location = "Corse", ObservedSpecies = "Tortue" };
			//Trips.Add(trip1);
			//Trips.Add(new TripModel() { Date = DateTime.Now, Location = "Cote atlantique", ObservedSpecies = "Baleine" });
			//Trips.Add(new TripModel() { Date = DateTime.Now, Location = "Metz", ObservedSpecies = "Requin" });

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
