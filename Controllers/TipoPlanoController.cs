using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlanoController : ControllerBase
    {
        private readonly ITipoPlanoRepositorio _tipoPlanoRepositorio;

        public TipoPlanoController(ITipoPlanoRepositorio tipoPlanoRepositorio)
        {
            _tipoPlanoRepositorio = tipoPlanoRepositorio;
        }

        [HttpGet("GetAllTipoPlano")]
        public async Task<ActionResult<List<TipoPlanoModel>>> GetAllTipoPlano()
        {
            List<TipoPlanoModel> tipoPlano = await _tipoPlanoRepositorio.GetAll();
            return Ok(tipoPlano);
        }

        [HttpGet("GetTipoPlanoId/{id}")]
        public async Task<ActionResult<TipoPlanoModel>> GetTipoPlanoId(int id)
        {
            TipoPlanoModel tipoPlano = await _tipoPlanoRepositorio.GetById(id);
            return Ok(tipoPlano);
        }

        [HttpPost("CreateTipoPlano")]
        public async Task<ActionResult<TipoPlanoModel>> InsertTipoPlano([FromBody]TipoPlanoModel tipoPlanoModel)
        {
            TipoPlanoModel tipoPlano = await _tipoPlanoRepositorio.InsertTipoPlano(tipoPlanoModel);
            return Ok(tipoPlano);
        }

        [HttpPut("UpdateTipoPlano/{id:int}")]
        public async Task<ActionResult<TipoPlanoModel>> UpdateTipoPlano(int id, [FromBody] TipoPlanoModel tipoPlanoModel)
        {
            tipoPlanoModel.TipoPlanoId = id;
            TipoPlanoModel tipoPlano = await _tipoPlanoRepositorio.UpdateTipoPlano(tipoPlanoModel, id);
            return Ok(tipoPlano);
        }

        [HttpDelete("DeleteTipoPlano/{id:int}")]

        public async Task<ActionResult<TipoPlanoModel>> DeleteTipoPlano(int id)
        {
            bool deleted = await _tipoPlanoRepositorio.DeleteTipoPlano(id);
            return Ok(deleted);
        }

    }
}
