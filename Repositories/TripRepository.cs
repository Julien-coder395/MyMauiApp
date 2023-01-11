using Kotlin;
using MyMauiApp.Models;

namespace MyMauiApp.Repositories;

public class TripRepository : BaseRepository<TripModel>
{
	// Ajout des données de test (s'il n'y en a pas).
	public async void SeedData()
	{
		var currentData = await GetList();
		if(currentData.Count == 0)
		{
			await Insert(new TripModel() { Id = 1, Date = DateTime.Now, Location = "Côte Atlantique - TEST", ObservedSpecies = "Baleine - TEST" });
			await Insert(new TripModel() { Id = 2, Date = DateTime.Now, Location = "Corse - TEST", ObservedSpecies = "Tortue - TEST" });
			await Insert(new TripModel() { Id = 3, Date = DateTime.Now, Location = "Côte bretonne - TEST", ObservedSpecies = "Requin - TEST" });
		}
	}
}

