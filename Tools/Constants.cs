namespace MyMauiApp.Tools
{
    public static class Constants
    {
        public const string DatabaseFilename = "SQLiteDb.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |

            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |

            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache |

            // le fichier est chiffré et inaccessible pendant que l’appareil est verrouillé.
            SQLite.SQLiteOpenFlags.ProtectionComplete;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
