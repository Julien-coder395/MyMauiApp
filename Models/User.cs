using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyMauiApp.Models
{
    public class User : ObservableObject
    {
		[PrimaryKey]
		public int Id { get; set; }
        
        private string login;
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

		private string password;
		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}
	}
}
