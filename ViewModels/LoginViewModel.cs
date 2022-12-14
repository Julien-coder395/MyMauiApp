using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Repositories;
using MyMauiApp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.ViewModels
{
	public class LoginViewModel : ObservableObject
	{
		public UserModel User { get; set; } = new UserModel();

		public UserRepository UserRepository { get; set; } = new();

		public RelayCommand SaveCommand { get; set; }

		public LoginViewModel()
		{
			SaveCommand = new RelayCommand(async () => await SaveUser());
		}

		public async Task SaveUser()
		{
			System.Diagnostics.Debug.WriteLine($"Login : {User.Login} / Password : {User.Password}");
			await UserRepository.SaveUserAsync(User);
		}

		// Méthode d'encryption pour transmettre le mot de passe crypté.
		public void OnEncrypt(string DecryptedText)
		{
			try
			{
				// Is there anything to encrypt?
				if (!string.IsNullOrEmpty(DecryptedText))
				{
					var encryptedBytes = new byte[0];
					// Get the password bytes.
					var passwordBytes = Encoding.UTF8.GetBytes(
						DecryptedText
						);
					// Get the salt bytes.
					var saltBytes = Encoding.UTF8.GetBytes(
						"1256"
						);
					// Create the algorithm
					using (var alg = Aes.Create())
					{
						// Set the block and key sizes.
						alg.KeySize = 256;
						alg.BlockSize = 128;
						// Derive the ACTUAL crypto key.
#pragma warning disable SYSLIB0041 // Le type ou le membre est obsolète
						var key = new Rfc2898DeriveBytes(
							passwordBytes,
							saltBytes,
							7 // Nb itérations
				
							);
#pragma warning restore SYSLIB0041 // Le type ou le membre est obsolète
								  // Generate the key and salt with proper lengths.
						alg.Key = key.GetBytes(alg.KeySize / 8);
						alg.IV = key.GetBytes(alg.BlockSize / 8);
						// Create the encryptor.
						using var enc = alg.CreateEncryptor(
							alg.Key,
							alg.IV
							);
						// Create a temporary stream.
						using var stream = new MemoryStream();
						// Create a cryptographic stream.
						using var cryptoStream = new CryptoStream(
							stream,
							enc,
							CryptoStreamMode.Write
							);
						// Create a writer
						using (var writer = new StreamWriter(
							cryptoStream
							))
						{
							// Write the bytes.
							writer.Write(
								DecryptedText
								);
						}
						// Get the bytes.
						encryptedBytes = stream.ToArray();
					}
					// Convert the bytes back to an encoded string.
					var encryptedValue = Convert.ToBase64String(
						encryptedBytes
						);
					// Update the UI.
					var EncryptedText = encryptedValue;
				}
				else
				{
					// Nothing to decrypt!
					//EncryptedText = "";
				}
			}
			catch (Exception)
			{
				
			}
		}
	}
}
