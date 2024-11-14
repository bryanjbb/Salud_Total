using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

[Route("api/[controller]")]
[ApiController]
public class DetalleVentaController : ControllerBase
{
    private readonly Detalle_VentaServices _detalleVentaService;

    public DetalleVentaController(Detalle_VentaServices detalleVentaService)
    {
        _detalleVentaService = detalleVentaService;
    }

    // Obtener detalles de una venta
    [HttpGet("GetDetallesVenta/{N_Factura}")]
    public async Task<ActionResult<IEnumerable<Detalle_Venta>>> GetDetallesVenta(long N_Factura)
    {
        var detalles = await _detalleVentaService.GetDetallesVenta(N_Factura);
        if (detalles == null || !detalles.Any())
        {
            return NotFound("No se encontraron detalles para esta venta.");
        }
        return Ok(detalles);
    }

    // Crear un nuevo detalle de venta
    [HttpPost]
    public async Task<ActionResult<string>> PostDetalleVenta([FromBody] Detalle_Venta detalleVenta)
    {
        var result = await _detalleVentaService.PostDetalle_Venta(detalleVenta);
        return Ok(result);
    }
}
