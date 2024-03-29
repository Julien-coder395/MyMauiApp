﻿using MyMauiApp.Models;
using MyMauiApp.Tools;
using SQLite;
using System.Diagnostics;

namespace MyMauiApp.Repositories
{
	public class BaseRepository<T> where T : BaseModel, new()
	{
		protected SQLiteAsyncConnection Database { get; private set; }

        public BaseRepository()
		{
			Init().GetAwaiter();
		}

		protected virtual async Task Init()
		{
			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags); ;
#if DEBUG
			Database.Tracer = new Action<string>(q => Debug.WriteLine(q));
            Database.Trace = true;
#endif
			await Database.CreateTableAsync<T>();
		}

		public async Task<T> GetById(int id) => await Database.FindAsync<T>(id);

		public virtual async Task<List<T>> GetList() => await Database.Table<T>().ToListAsync();

		public virtual async Task<int> Insert(T entity) => await Database.InsertAsync(entity);

		public virtual async Task<int> Update(T entity) => await Database.UpdateAsync(entity);

		public virtual async Task<int> Delete(T entity) => await Database.DeleteAsync(entity);

		public virtual async Task ClearTable() => await Database.DeleteAllAsync<T>();
	}
}
