using MyMauiApp.Tools;

namespace MyMauiApp.Views;

public partial class ComposantTest : ContentView
{
	public ComposantTest()
	{
		InitializeComponent();
		if(Helper.HasLogin)
		{
			label.Text = "Utilisateur loggé";
		}
		else
		{
			label.Text = "Pas loggé";
		}
	}
}