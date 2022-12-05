using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		
		private Timer _timer;

		private DateTime _dateTime;
		public DateTime DateTime
		{
			get => _dateTime;
			set
			{
				if (_dateTime != value)
				{
					_dateTime = value;
					OnPropertyChanged();
				}
			}
		}

		public MainViewModel()
		{
			this.DateTime = DateTime.Now;

			// Update the DateTime property every second.
			_timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
							   null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
		}

		~MainViewModel() =>
		_timer.Dispose();

		public void OnPropertyChanged([CallerMemberName] string name = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
