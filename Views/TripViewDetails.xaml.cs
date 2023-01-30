namespace MyMauiApp.Views;

public partial class TripViewDetails : ContentPage
{
	public TripViewDetails()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}