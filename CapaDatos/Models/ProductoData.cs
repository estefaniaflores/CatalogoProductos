using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models
{
    public class ProductoData(string connectionString)
    {
        private readonly string _connectionString = connectionString;
        
        public List<Producto> GetAllProductos()
        {
            List<Producto> productos = [];
            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT Id, Nombre, Descriocion, FotoUrl, Categoria FROME Productos";
                SqlCommand command = new(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    productos.Add(
                        new Producto
                        {

                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            FotoUrl = reader.GetString(3),
                            Categoria = reader.GetString(4)

                        }
                    );
                }
            }
            return productos;
        }
        public Producto GetProductoById(int id)
        {
            Producto producto = new();
            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT Id, Nombre, Descripcion, FotoUrl, Categoria FROME Productos WHERE Id=@Id";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    producto =
                        new Producto
                        {

                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            FotoUrl = reader.GetString(3),
                            Categoria = reader.GetString(4)

                        };
                }
            }
            return producto;
        }

        public void AddProductos(Producto producto)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "INSERT INTO Productos (Nombre, Descripcion, FotoUrl, Categoria) VALUES (@Nombre, @Descripcion, @FotoUrl, @Categoria)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@FotoUrl", producto.FotoUrl);
            command.Parameters.AddWithValue("@Categoria", producto.Categoria);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateProducto(Producto producto)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "UPDATE Productos SET Names=@Nombre, Descripcion=@Descripcion, FotoUrl=@FotoUrl, Categoria=@Categoria WHERE Id=@Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", producto.Id);
            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@FotoUrl", producto.FotoUrl);
            command.Parameters.AddWithValue("@Categoria", producto.Categoria);
            connection.Open(); 
            command.ExecuteNonQuery();
        }
        public void DeleteProducto(int id)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "DELETE FROM Productos WHERE Id=@Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
