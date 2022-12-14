using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace MyMauiApp.ViewModels
{
	public class AsyncAwaitViewModel : ObservableObject
	{
		private readonly HttpClient client = new();

		public ICommand DownloadCommand { get; set; }

		public ICommand DisplayMessageCommand { get; set; }

		private string message;
		public string Message
		{ 
			get => message;
			set => SetProperty(ref message, value);
		}

		private string downloadStatus;
		public string DownloadStatus
		{
			get => downloadStatus;
			set => SetProperty(ref downloadStatus, value);
		}

		public AsyncAwaitViewModel()
		{
			//DownloadCommand = new RelayCommand(async () => await DownloadAsync());
			DownloadCommand = new RelayCommand(Download);
			DisplayMessageCommand = 
				new RelayCommand(() => Message = string.IsNullOrEmpty(Message) ? 
								"Hello .NET MAUI -- MVVM -- Async Await" 
								: string.Empty);
		}

		private async Task DownloadAsync()
		{ 		
			try
			{
				DownloadStatus = "Téléchargement en cours...";
				byte[] content = await client.GetByteArrayAsync("https://speed.hetzner.de/100MB.bin");
				//byte[] content = await client.GetByteArrayAsync("https://speed.hetzner.de/1GB.bin");
				DownloadStatus = "Fin du téléchargement";
			}
			catch(Exception ex)
			{
				DownloadStatus = ex.Message;
			}	
		}

		private void Download()
		{
			try
			{
				DownloadStatus = "Téléchargement en cours...";
				byte[] content = client.GetByteArrayAsync("https://speed.hetzner.de/100MB.bin").GetAwaiter().GetResult();
				//byte[] content = await client.GetByteArrayAsync("https://speed.hetzner.de/1GB.bin");
				DownloadStatus = "Fin du téléchargement";
			}
			catch (Exception ex)
			{
				DownloadStatus = ex.Message;
			}
		}
	}
}
