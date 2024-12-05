using CRUD_MVVM2_Q42024.Models;
using SQLite;

namespace CRUD_MVVM2_Q42024.Services
{
    public class ProductoService
    {
        private readonly SQLiteConnection connection;

        public ProductoService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<Producto>();
        }

        public List<Producto> GetAll()
        {
            var res = connection.Table<Producto>().ToList();
            return res;
        }

        public int Insert(Producto producto)
        {
            return connection.Insert(producto);
        }

        public int Update(Producto producto)
        {
            return connection.Update(producto);
        }

        public int Delete(Producto producto)
        {
            return connection.Delete(producto); 
        }
    }
}
