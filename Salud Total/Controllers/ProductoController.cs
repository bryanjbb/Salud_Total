using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

namespace Salud_Total.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServices _productoServices;

        public ProductoController(ProductoServices productoServices)
        {
            _productoServices = productoServices;
        }
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Producto>>> GetID(int ID)
        {
            var producto = await _productoServices.GetProducto(ID);
            return Ok(producto);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Producto _Oproducto)
        {
            await _productoServices.PostProducto(_Oproducto);
            return Ok("Producto registrados");
        }

        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Producto _Oproducto)
        {
            await _productoServices.PutProducto(_Oproducto);
            return Ok("Producto Actualizado");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _productoServices.DeleteProducto(id);
            return Ok(resultado);
        }
    }
}
