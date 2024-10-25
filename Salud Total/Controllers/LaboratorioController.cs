using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salud_Total.Models;
using Salud_Total.Services;

namespace Salud_Total.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorioController : ControllerBase
    {
        private readonly LaboratorioServices _laboratorioServices;

        public LaboratorioController(LaboratorioServices laboratorioServices)
        {
            _laboratorioServices = laboratorioServices;
        }
        [HttpGet]
        [Route("GetID/{ID}")]

        public async Task<ActionResult<List<Laboratorio>>> GetID(int ID)
        {
            var laboratorio = await _laboratorioServices.GetLaboratorio(ID);
            return Ok(laboratorio);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult> Post(Laboratorio _Olaboratorio)
        {
            await _laboratorioServices.PostLaboratorio(_Olaboratorio);
            return Ok("Laboratorio agregada");
        }

        [HttpPut]
        [Route("Put")]

        public async Task<ActionResult> Put(Laboratorio _Olaboratorio)
        {
            await _laboratorioServices.PutLaboratorio(_Olaboratorio);
            return Ok("Laboratorio Actualizado");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _laboratorioServices.DeleteLaboratorio(id);
            return Ok(resultado);
        }
    }
}

    
