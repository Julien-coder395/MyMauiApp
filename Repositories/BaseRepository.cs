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
	public class BaseRepository<T> where T : BaseModel, new()
	{
		protected SQLiteAsyncConnection Database;

		public BaseRepository()
		{
			Init().GetAwaiter();
		}

		protected virtual async Task Init()
		{
			Database ??= new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
			await Database.CreateTableAsync<T>();
		}

		public async Task<T> GetById(int id)
		{
			return await Database.FindAsync<T>(id);
		}

		public async Task<List<T>> GetList() => await Database.Table<T>().ToListAsync();

		public async Task<int> Insert(T entity) => await Database.InsertAsync(entity);

		public async Task<int> Update(T entity) => await Database.UpdateAsync(entity);

		public async Task<int> Delete(T entity) => await Database.DeleteAsync(entity);
	}
}
