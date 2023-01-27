using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyMauiApp.Models
{
    public partial class TripModel : BaseModel
	{
        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private int profondeur;

        [ObservableProperty]
        private string location = string.Empty;

        [ObservableProperty]
        private string observedSpecies = string.Empty;

		// Id du DiveSpotModel associé à ce TripModel.
		public int DiveSpotId { get; set; }

        [Ignore]
        public DiveSpotModel DiveSpotModel { get; set; } = new();
    }
}
