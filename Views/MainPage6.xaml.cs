using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class MainPage6 : ContentPage
{
	public MainPage6()
	{
		InitializeComponent();
		MainViewModel6 vm = new();
		BindingContext= vm;
	}
}