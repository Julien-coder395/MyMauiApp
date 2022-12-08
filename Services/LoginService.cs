using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;
using static Android.Content.ClipData;

namespace MyMauiApp.Services
{
	public class LoginService
	{
		private HttpClient httpClient = new();

		string url = "https://localhost:7117";

		public LoginService()
		{
		}
		
		public async Task Register(string login, string password)
		{
			var dto = new UserDto
			{
				Username = login,
				Password = password
			};

			var json = JsonSerializer.Serialize<UserDto>(dto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var urlRegister = $"{url}/api/Auth/register";
			await httpClient.PostAsync(urlRegister, content);
		}
	}

	public class UserDto
	{
		public string Username { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;
	}
}
