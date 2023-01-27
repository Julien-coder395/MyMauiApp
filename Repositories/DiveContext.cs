using Microsoft.EntityFrameworkCore;
using MyMauiApp.Models;
using MyMauiApp.Tools;
using SQLite;

namespace MyMauiApp.Repositories
{
    public class DiveContext : DbContext
    {
        public DbSet<DiveSpotModel> Spots { get; set; }
        public DbSet<TripModel> Trips { get; set; }

        private SQLiteConnection DbConnection { get; set; }

        public string DbPath { get; }

        public DiveContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "testEFCoreSQLite.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            CreateTables();
            options.UseSqlite($"Data Source={DbPath}");
            //Database.Migrate();
        }

        private void CreateTables()
        {
            DbConnection = new SQLiteConnection(DbPath);
            DbConnection.CreateTable<DiveSpotModel>();
            DbConnection.CreateTable<TripModel>();
        }
    }
}
