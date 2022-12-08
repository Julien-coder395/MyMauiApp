using MyMauiApp.Models;
using MyMauiApp.Tools;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Repositories
{
    public class UserRepository
	{
		SQLiteAsyncConnection Database;

		public UserRepository()
		{
			Init().GetAwaiter();
		}

		async Task Init()
		{
			if (Database is not null)
				return;

			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
			_ = await Database.CreateTableAsync<User>();
		}

		public async Task<User> GetUserAsync()
		{
			var user = await Database.Table<User>().ToListAsync();
			return user;
		}

		public async Task<int> SaveUserAsync(User user)
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
