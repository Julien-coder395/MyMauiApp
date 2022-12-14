namespace MyMauiApp.Tools
{
	public static class MenuHelper
    {
		public static event EventHandler MenuChange;

		public static void ChangeMenu(object sender, EventArgs e)
		{
			MenuChange(sender, e);
		}
	}
}
