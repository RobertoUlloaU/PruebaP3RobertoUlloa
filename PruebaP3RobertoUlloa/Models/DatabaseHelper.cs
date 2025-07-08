using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PruebaP3RobertoUlloa.Models
{
    

    public class DatabaseHelper
    {
        private readonly SQLiteConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Dispositivo>();
        }

        public int SaveDispositivo(Dispositivo dispositivo)
        {
            if (dispositivo.Id != 0)
            {
                return _database.Update(dispositivo);
            }
            else
            {
                return _database.Insert(dispositivo);
            }
        }

        public List<Dispositivo> GetDispositivos()
        {
            return _database.Table<Dispositivo>().ToList();
        }
    }

}
