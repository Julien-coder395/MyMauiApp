﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	public class BaseViewModel<TRepository, TModel> : ObservableObject 
		where TRepository : BaseRepository<TModel>, new()
		where TModel : BaseModel, new()	
	{
		protected TRepository Repository { get; set; }

		public ICommand AddTestDataCommand { get; set; }

		public BaseViewModel(TRepository repo)
		{
			Repository = repo;
		}
	}
}
