using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

namespace Salud_Total.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private readonly PresentacionServices _presentacionServices;

        public PresentacionController(PresentacionServices presentacionServices)
        {
            _presentacionServices = presentacionServices;
        }
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Presentacion>>> GetID(int ID)
        {
            var presentacion = await _presentacionServices.GetPresentacion(ID);
            return Ok(presentacion);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Presentacion _Opresentacion)
        {
            await _presentacionServices.PostPresentacion(_Opresentacion);
            return Ok("Presentacion agregada");
        }

        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Presentacion _Opresentacion)
        {
            await _presentacionServices.PutPresentacion(_Opresentacion);
            return Ok("Presentacion Actualizado");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _presentacionServices.DeletePresentacion(id);
            return Ok(resultado);
        }
    }
}
