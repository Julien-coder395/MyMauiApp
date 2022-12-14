using MyMauiApp.Components;
using MyMauiApp.Tools;

namespace MyMauiApp.Views;

public partial class LogBookView : ContentPage
{
	private Dictionary<string, ContentView> dicoContentViews { get; set; }

	public LogBookView()
	{
		InitializeComponent();
		var statsBody = new StatsBody();
		Body.Content = statsBody;
		MenuHelper.MenuChange += MenuHelper_MenuChange;
		dicoContentViews = new Dictionary<string, ContentView>
		{
			{"Statistiques", statsBody },
			{"Liste", new ListBody() },
			{"Ajouter", new AddBody() }
		};
	}

	private void MenuHelper_MenuChange(object sender, EventArgs e)
	{
		Body.Content = dicoContentViews[(sender as Label).Text];
	}
}