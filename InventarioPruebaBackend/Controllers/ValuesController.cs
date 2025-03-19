using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private static List<string> productos = new() { "Producto1", "Producto2", "Producto3" };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(productos);
    }
}
