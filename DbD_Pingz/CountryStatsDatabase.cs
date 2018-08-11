using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbD_Pingz
{
    class CountryStatsDatabase : IDisposable
    {
        private SQLiteConnection sQLiteConnection;

        private bool disposed = false;

        public CountryStatsDatabase(string databaseURI)
        {
            if (!File.Exists(databaseURI))
            {
                SQLiteConnection.CreateFile(databaseURI);
            }

            sQLiteConnection = new SQLiteConnection();
            sQLiteConnection.ConnectionString = "Data Source=" + databaseURI;
            sQLiteConnection.Open();

            SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS pingz_countrytable (countrycode TEXT PRIMARY KEY NOT NULL, amount INTEGER NOT NULL);";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void IncrementCountry(string countrycode) // _unknown for non resolved ips
        {
            if (countrycode != null)
            {
                SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);
                cmd.CommandText = "INSERT OR REPLACE INTO pingz_countrytable (countrycode, amount) VALUES ('" + countrycode + "', COALESCE((SELECT amount + 1 FROM pingz_countrytable WHERE countrycode = '" + countrycode + "'),1));";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public void PrintTableDebugList()
        {
            SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);
            cmd.CommandText = "SELECT * FROM pingz_countrytable";

            SQLiteDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            DataTable data = new DataTable();
            data.Load(dataReader);

            foreach(DataRow row in data.Rows)
            {
                Console.WriteLine(row[0] + " - " + row[1]);
            }

            cmd.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Disposing CountryStats object");
            if (disposed)
                return;
            if (disposing)
            {
                //Managed objects here
            }
            if (sQLiteConnection != null)
                sQLiteConnection.Dispose();

            disposed = true;
        }

        ~CountryStatsDatabase()
        {
            Dispose(false);
        }
    }
}
