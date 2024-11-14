using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

namespace Salud_Total.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaServices _ventaServices;

        public VentaController(VentaServices ventaServices)
        {
            _ventaServices = ventaServices;
        }
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Venta>>> GetID(int ID)
        {
            var presentacion = await _ventaServices.GetVenta(ID);
            return Ok(presentacion);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Venta _Oventa)
        {
            await _ventaServices.PostVenta(_Oventa);
            return Ok("Venta agregada");
        }

       
    }
}
