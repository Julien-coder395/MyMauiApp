using MyMauiApp.Models;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class TripView : ContentPage
{
	private TripViewModel TripViewModel { get; set; }
	
	public TripView()
	{
		InitializeComponent();
		TripViewModel = BindingContext as TripViewModel;
	}

	private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var item = e.SelectedItem as TripModel;
		TripViewModel.DeleteCommand.Execute(item);
	}
}