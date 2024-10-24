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
    public class TipoProfissionalController : ControllerBase
    {
        private readonly ITipoProfissionalRepositorio _tipoProfissionalRepositorio;

        public TipoProfissionalController(ITipoProfissionalRepositorio tipoProfissionalRepositorio)
        {
            _tipoProfissionalRepositorio = tipoProfissionalRepositorio;
        }

        [HttpGet("GetAllTipoProfissional")]
        public async Task<ActionResult<List<TipoProfissionalModel>>> GetAllTipoProfissional()
        {
            List<TipoProfissionalModel> tipoProfissional = await _tipoProfissionalRepositorio.GetAll();
            return Ok(tipoProfissional);
        }

        [HttpGet("GetTipoProfissionalId/{id}")]
        public async Task<ActionResult<TipoProfissionalModel>> GetTipoProfissionalId(int id)
        {
            TipoProfissionalModel tipoProfissional = await _tipoProfissionalRepositorio.GetById(id);
            return Ok(tipoProfissional);
        }

        [HttpPost("CreateTipoProfissional")]
        public async Task<ActionResult<TipoProfissionalModel>> InsertTipoProfissional([FromBody]TipoProfissionalModel tipoProfissionalModel)
        {
            TipoProfissionalModel tipoProfissional = await _tipoProfissionalRepositorio.InsertTipoProfissional(tipoProfissionalModel);
            return Ok(tipoProfissional);
        }

        [HttpPut("UpdateTipoProfissional/{id:int}")]
        public async Task<ActionResult<TipoProfissionalModel>> UpdateTipoProfissional(int id, [FromBody] TipoProfissionalModel tipoProfissionalModel)
        {
            tipoProfissionalModel.TipoProfissionalId = id;
            TipoProfissionalModel tipoProfissional = await _tipoProfissionalRepositorio.UpdateTipoProfissional(tipoProfissionalModel, id);
            return Ok(tipoProfissional);
        }

        [HttpDelete("DeleteTipoProfissional/{id:int}")]

        public async Task<ActionResult<TipoProfissionalModel>> DeleteTipoProfissional(int id)
        {
            bool deleted = await _tipoProfissionalRepositorio.DeleteTipoProfissional(id);
            return Ok(deleted);
        }


    }
}
