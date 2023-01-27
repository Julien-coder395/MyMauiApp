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

	private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var item = e.SelectedItem as TripModel;
		TripViewModel.DeleteCommand.Execute(item);
	}
}