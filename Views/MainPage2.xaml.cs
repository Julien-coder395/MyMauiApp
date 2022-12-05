using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class MainPage2 : ContentPage
{
	public MainPage2()
	{
		InitializeComponent();
		// On effectue l'association du ViewModel et du BindingContext dans le code-behing de la vue.

		MainViewModel2 mainViewModel2 = new();
		BindingContext = mainViewModel2;
	}
}