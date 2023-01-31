using Microsoft.Extensions.DependencyInjection;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class TripView : ContentPage
{
	private TripViewModel TripViewModel { get; set; }
	
	public TripView()
	{
		InitializeComponent();
        TripViewModel = ServiceHelper.GetService<TripViewModel>();
		BindingContext = TripViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListViewTrips.SelectedItem = null;
    }


    private async void ListViewTrips_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if(e.Item is not null)
        {
            TripViewModel.TripDetails = e.Item as TripModel;
            TripViewDetails detailPage = new() { BindingContext = TripViewModel };
            await Navigation.PushAsync(detailPage);
        }    
    }
}