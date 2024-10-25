using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        //Metodo para listar los datos de la tabla compra//
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Compra>>> GetID(int ID)
        {
            var compra = await _compraServices.GetCompra(ID);
            return Ok(compra);
        }
        //Metodo para agragar datos//
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Compra _OCompra)
        {
            await _compraServices.PostCompra(_OCompra);
            return Ok("Compra registrada");
        }

        //Metodo para actualizar los datos existentes de la tabla compra
        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Compra _OCompra)
        {
            await _compraServices.PutCompra(_OCompra);
            return Ok("Compra Actualizada");
        }
    }
}
