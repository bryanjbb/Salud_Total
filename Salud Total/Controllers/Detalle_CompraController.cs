using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

[Route("api/[controller]")]
[ApiController]
public class DetalleCompraController : ControllerBase
{
    private readonly Detalle_CompraServices _detalleCompraService;

    public DetalleCompraController(Detalle_CompraServices detalleCompraService)
    {
        _detalleCompraService = detalleCompraService;
    }

    // Método GET para obtener los detalles de una compra específica
    [HttpGet("GetDetallesCompra/{N_Compra}")]
    public async Task<ActionResult<IEnumerable<Detalle_Compra>>> GetDetallesCompra(long N_Compra)
    {
        try
        {
            // Llamamos al servicio para obtener los detalles de compra por N_Compra
            var detalles = await _detalleCompraService.GetDetallesCompra(N_Compra);

            // Si no se encuentran detalles de la compra, devolvemos un error 404
            if (detalles == null || !detalles.Any())
            {
                return NotFound("No se encontraron detalles para esta compra.");
            }

            // Si se encuentran detalles, devolvemos la lista con un código 200 OK
            return Ok(detalles);
        }
        catch (Exception ex)
        {
            // Si ocurre un error en el proceso, devolvemos un error 500
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    
        // POST: api/DetalleCompra/InsertarDetalleCompra
        [HttpPost("InsertarDetalleCompra")]
        public async Task<ActionResult<string>> PostDetalle_Compra([FromBody] Detalle_Compra detalleCompra)
        {
            try
            {
                // Llamamos al servicio para insertar el detalle de compra
                var resultado = await _detalleCompraService.InsertarDetalleCompra(detalleCompra);

                // Si el resultado es exitoso, devolvemos un mensaje de éxito con código 200
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos un error 500
                return StatusCode(500, $"Error al guardar el detalle de compra: {ex.Message}");
            }
        }
    }


