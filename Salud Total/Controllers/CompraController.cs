using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

namespace Salud_Total.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraServices _compraServices;

        public CompraController(CompraServices compraServices)
        {
            _compraServices = compraServices;
        }
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Compra>>> GetID(int ID)
        {
            var producto = await _compraServices.GetCompra(ID);
            return Ok(producto);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Compra _Ocompra)
        {
            await _compraServices.PostCompra(_Ocompra);
            return Ok("Compra registrada");
        }

        }
}