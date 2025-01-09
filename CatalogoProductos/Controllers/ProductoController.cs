using CapaDatos.Models;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProductos.Controllers
{
    public class ProductoController(ProductoService productoService) : Controller
    {
        private readonly ProductoService _productoService = productoService;
        public IActionResult Index()
        {
            try
            {
                var productos = _productoService.GetAllProductos();
                return View(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje="error"});
            }
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productoService.AddProducto(producto);
                    return RedirectToAction("Index");
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje="error"});
            }
           
        }
        public IActionResult Edit(int id)
        {
            
            try
            {
                Producto producto = _productoService.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "error" });
            }
        }
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productoService.UpdateProducto(producto);
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "error" });
            }
            
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Producto producto = _productoService.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "error" });
            }
            
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _productoService.DeleteProdcuto(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "error" });
            }
            
        }
    }
}
