using CommunityToolkit.Mvvm.ComponentModel;

namespace MyMauiApp.Models
{
    public partial class DiveSpotModel : BaseModel
    {
        [ObservableProperty]
        private string name = string.Empty;

        // Point GPS
        [ObservableProperty]
        private string gpsLocalisation = string.Empty;

        [ObservableProperty]
        private string pays = string.Empty;

        [ObservableProperty]
        private string diveSpotRegion = string.Empty;
    }
}
