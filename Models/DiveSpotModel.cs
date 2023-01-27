namespace MyMauiApp.Models
{
    public class DiveSpotModel : BaseModel
    {
        //public int DiveSpotModelID { get; set; }

        // Propriété
        private string diveSpotName = string.Empty;
        public string DiveSpotName
        {
            get => diveSpotName;
            set => SetProperty(ref diveSpotName, value);
        }

        // Propriété
        // Point GPS
        private string diveSpotLocalisation = string.Empty;
        public string DiveSpotLocalisation
        {
            get => diveSpotLocalisation;
            set => SetProperty(ref diveSpotLocalisation, value);
        }

        // Propriété
        private string diveSpotPays = string.Empty;
        public string DiveSpotPays
        {
            get => diveSpotPays;
            set => SetProperty(ref diveSpotPays, value);
        }

        // Propriété
        private string diveSpotRegion = string.Empty;
        public string DiveSpotRegion
        {
            get => diveSpotRegion;
            set => SetProperty(ref diveSpotRegion, value);
        }
    }
}
