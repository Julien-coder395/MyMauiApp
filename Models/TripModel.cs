using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyMauiApp.Models
{
	public class TripModel : BaseModel
	{
		private DateTime date = DateTime.Now;
		public DateTime Date
		{
			get => date;
			set => SetProperty(ref date, value);
		}

		//[ObservableProperty]
		//DateTime date;

		private int profondeur;
		public int Profondeur
		{
			get => profondeur;
			set => SetProperty(ref profondeur, value);
		}

		private string location = string.Empty;
		public string Location
		{
			get => location;
			set => SetProperty(ref location, value);
		}

		private string observedSpecies = string.Empty;
		public string ObservedSpecies
		{
			get => observedSpecies;
			set => SetProperty(ref observedSpecies, value);
		}

		// Id du DiveSpotModel associé à ce TripModel.
		public int DiveSpotId { get; set; }

		private DiveSpotModel diveSpotModel = new();
        [Ignore] // N'est pas sauvegardé par SQLite
        public DiveSpotModel DiveSpotModel
		{
			get => diveSpotModel;
			set => SetProperty(ref diveSpotModel, value);
		}
	}
}
