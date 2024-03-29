﻿using MyMauiApp.Models;

namespace MyMauiApp.Repositories
{
	public class UserRepository : BaseRepository<UserModel>
	{		
		public UserRepository()
		{
		}

		public async Task<UserModel> GetUserAsync()
		{
			var user = await Database.Table<UserModel>().FirstOrDefaultAsync();
			return user;
		}

		public async Task<int> SaveUserAsync(UserModel user)
		{
			var userSaved = GetUserAsync();
			if(userSaved != null)
			{
				user.Id = userSaved.Id;
				return await Database.UpdateAsync(user);
			}
			else
			{
				user.Id = 0;
				return await Database.InsertAsync(user);
			}
		}
	}
}
