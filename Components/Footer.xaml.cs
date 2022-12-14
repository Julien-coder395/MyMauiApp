using MyMauiApp.Tools;

namespace MyMauiApp.Components;

public partial class Footer : ContentView
{
	public Footer()
	{
		InitializeComponent();		
	}

	private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		MenuHelper.ChangeMenu(sender, e);
	}
}