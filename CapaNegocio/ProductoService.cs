using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Models;
namespace CapaNegocio
{
    public class ProductoService
    {
        private readonly ProductoData _productoData;
        public ProductoService(string connectionString) 
        {
            _productoData = new ProductoData(connectionString);
        }

        public List<Producto> GetAllProductos() 
        {
            return _productoData.GetAllProductos();
        }
        public  Producto GetProductoById(int id)
        {
            return _productoData.GetProductoById(id);
        }

        public void AddProducto (Producto producto) 
        { 
            _productoData.AddProductos(producto);
            
        }
        public void UpdateProducto(Producto producto)
        {
            _productoData.UpdateProducto(producto);

        }
        public void DeleteProdcuto(int id)
        {
            _productoData.DeleteProducto(id);

        }
    }
}
