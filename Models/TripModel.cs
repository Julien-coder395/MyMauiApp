using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Models
{
	public class TripModel : BaseModel
	{
		private DateTime date = DateTime.Now;
		public DateTime Date
		{
			get => date;
			set => SetProperty(ref date, value);
		}

		private string location;
		public string Location
		{
			get => location;
			set => SetProperty(ref location, value);
		}

		private string observedSpecies;
		public string ObservedSpecies
		{
			get => observedSpecies;
			set => SetProperty(ref observedSpecies, value);
		}
	}
}
