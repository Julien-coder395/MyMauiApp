using Java.Util;
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
		// 3 niveaux de protection : private / protected / public

		// Constructeur
		//public TripModel(DateTime date, string location)
		//{
		//	Date = date;
		//	Location = location;
		//	Sumarize();
		//}

		private DateTime date = DateTime.Now;
		public DateTime Date
		{
			get => date;
			set => SetProperty(ref date, value);
		}

		//public DateTime GetDate()
		//{
		//	return date;
		//}

		//public void SetDate(DateTime date)
		//{
		//	this.date = date;
		//}

		private string location = string.Empty;
		public string Location
		{
			get => location;
			set => SetProperty(ref location, value);
		}

		private string observedSpecies = string.Empty;
		public string ObservedSpecies
		{
			get => observedSpecies;
			set => SetProperty(ref observedSpecies, value);
		}

		public string Sumarize()
		{
			return $"Le trip a lieu: {Location} + {Id}";
		}

		public void Add2jours()
		{
			Date.AddDays(2);
		}
	}
}
