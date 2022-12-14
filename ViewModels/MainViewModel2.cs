using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	// La View correspondante est MainPage2.
	internal class MainViewModel2 : ObservableObject
	{
		//Avec une List, lorsqu'on y ajoute un élément, le rafraîchissement de la vue ne s'effectue pas.
		//private List<string> dataStrings = new();
		//public List<string> DataStrings
		//{
		//	get => dataStrings;
		//	set
		//	{
		//		dataStrings = value;
		//		OnPropertyChanged(); // Méthode de la classe mère
		//	}
		//}

		// Avec une ObservableCollection, lorsqu'on y ajoute un élément, le rafraîchissement de la vue s'effectue
		private ObservableCollection<string> dataStrings = new();
		public ObservableCollection<string> DataStrings
		{
			get => dataStrings;
			set
			{
				dataStrings = value;
				//OnPropertyChanged(); // Méthode de la classe mère
			}
		}

		private Dictionary<string, string> dico = new();
		public Dictionary<string, string> Dico
		{
			get => dico;
			set
			{
				dico = value;
				//OnPropertyChanged(); // Méthode de la classe mère
			}
		}

		private string inputText;
		public string InputText
		{
			get => inputText;
			set
			{
				inputText = value;
				//OnPropertyChanged(); // Méthode de la classe mère
			}
		}

		// Command permettant d'associer l'appuie sur le bouton avec une méthode du ViewModel.
		public ICommand PressButtonCommand { private set; get; }

		public MainViewModel2()
		{
			DataStrings.Add("Item1");
			DataStrings.Add("Item2");
			DataStrings.Add("Item3");
			DataStrings.Add("Item4");

			for(int i = 0; i < 4; i++)
			{
				Dico.Add($"Key{i}", $"Value{i}");
			}

			PressButtonCommand = new Command(PressButton);
		}

		private void PressButton()
		{
			Debug.WriteLine($"\n\nInput Text : {InputText}");
			var count = dico.Count;
			for (int i = count; i < count + 4; i++)
			{
				Dico.Add($"Key{i}", $"Value{i}");
			}

			count = DataStrings.Count;
			for (int i = count; i < count + 4; i++)
			{
				DataStrings.Add($"Item {i}");
			}
		}
	}
}
