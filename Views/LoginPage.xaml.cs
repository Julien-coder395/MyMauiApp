using MyMauiApp.Tools;

namespace MyMauiApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		UpdateSource();
	}

	/// <summary>
	/// Met à jour la source de l'image bouton en bas à droite
	/// </summary>
	private void UpdateSource()
	{
		if (Helper.HasLogin)
		{
			btn_bottom_right.ImageSource = "image_has_login.png";
		}
		else
		{
			btn_bottom_right.ImageSource = "image_has_no_login.png";
		}
	}
}