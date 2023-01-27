using MyMauiApp.Models;

namespace MyMauiApp.Repositories;

public class TripRepository : BaseRepository<TripModel>
{
	public DiveSpotRepository DiveSpotRepository { get; set; }
	
	public TripRepository()
	{
		DiveSpotRepository = ServiceHelper.GetService<DiveSpotRepository>();
	}
	
	// Ajout des données de test (s'il n'y en a pas).
	public async void SeedData()
	{
		var currentData = await GetList();
		if (currentData.Count == 0)
		{
			await Insert(new TripModel() { Id = 1, Date = DateTime.Now, Location = "Côte Atlantique - TEST", ObservedSpecies = "Baleine - TEST" });
			await Insert(new TripModel() { Id = 2, Date = DateTime.Now, Location = "Corse - TEST", ObservedSpecies = "Tortue - TEST" });
			await Insert(new TripModel() { Id = 3, Date = DateTime.Now, Location = "Côte bretonne - TEST", ObservedSpecies = "Requin - TEST" });
		}
	}

    public async override Task<List<TripModel>> GetList()
    {
        var trips = await base.GetList();
		foreach(var trip in trips)
		{
			var diveSpot = await DiveSpotRepository.GetById(trip.DiveSpotId);
			trip.DiveSpotModel = diveSpot;
		}
		return trips;
    }

    public async override Task<int> Insert(TripModel trip)
    {
		await DiveSpotRepository.Insert(trip.DiveSpotModel);
		trip.DiveSpotId = trip.DiveSpotModel.Id;
		return await base.Insert(trip);
    }

    public async override Task<int> Update(TripModel trip)
    {
		await DiveSpotRepository.Update(trip.DiveSpotModel);
		return await base.Update(trip);
    }

    public async override Task<int> Delete(TripModel trip)
    {
		if (trip != null)
		{
			if (trip.DiveSpotModel != null)
			{
				await DiveSpotRepository.Delete(trip.DiveSpotModel);
			}
			return await base.Delete(trip);
		}
		return 0;
    }
}

