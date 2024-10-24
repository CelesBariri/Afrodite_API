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
    public class TipoClubeController : ControllerBase
    {
        private readonly ITipoClubeRepositorio _tipoClubeRepositorio;

        public TipoClubeController(ITipoClubeRepositorio tipoClubeRepositorio)
        {
            _tipoClubeRepositorio = tipoClubeRepositorio;
        }

        [HttpGet("GetAllTipoClube")]
        public async Task<ActionResult<List<TipoClubeModel>>> GetAllTipoClube()
        {
            List<TipoClubeModel> tipoClube = await _tipoClubeRepositorio.GetAll();
            return Ok(tipoClube);
        }

        [HttpGet("GetTipoClubeId/{id}")]
        public async Task<ActionResult<TipoClubeModel>> GetTipoClubeId(int id)
        {
            TipoClubeModel tipoClube = await _tipoClubeRepositorio.GetById(id);
            return Ok(tipoClube);
        }

        [HttpPost("CreateTipoClube")]
        public async Task<ActionResult<TipoClubeModel>> InsertTipoClube([FromBody]TipoClubeModel tipoClubeModel)
        {
            TipoClubeModel tipoClube = await _tipoClubeRepositorio.InsertTipoClube(tipoClubeModel);
            return Ok(tipoClube);
        }

        [HttpPut("UpdateTipoClube/{id:int}")]
        public async Task<ActionResult<TipoClubeModel>> UpdateTipoClube(int id, [FromBody] TipoClubeModel tipoClubeModel)
        {
            tipoClubeModel.TipoClubeId = id;
            TipoClubeModel tipoClube = await _tipoClubeRepositorio.UpdateTipoClube(tipoClubeModel, id);
            return Ok(tipoClube);
        }

        [HttpDelete("DeleteTipoClube/{id:int}")]

        public async Task<ActionResult<TipoClubeModel>> DeleteTipoClube(int id)
        {
            bool deleted = await _tipoClubeRepositorio.DeleteTipoClube(id);
            return Ok(deleted);
        }

    }
}
