using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyMauiApp.Models
{
	public class BaseModel : ObservableObject
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}
