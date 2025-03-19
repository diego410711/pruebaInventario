using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventarioPruebaBackend.Data;

[Route("productos")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET /productos/inventario
    [HttpGet("inventario")]
    [Authorize]
    public IActionResult GetInventario()
    {
        var productos = _context.Productos.ToList();
        return Ok(productos);
    }

    // POST /productos/movimiento
    [HttpPost("movimiento")]
    [Authorize]
    public IActionResult MovimientoProducto([FromBody] MovimientoRequest request)
    {
        var producto = _context.Productos.FirstOrDefault(p => p.Id == request.ProductoId);
        if (producto == null)
            return NotFound("Producto no encontrado");

        producto.Cantidad += request.Cantidad;
        _context.SaveChanges();

        return Ok(producto);
    }
}

public class MovimientoRequest
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; } // Puede ser negativo para salidas
}
