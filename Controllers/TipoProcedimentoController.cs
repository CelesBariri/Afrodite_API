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
    public class TipoProcedimentoController : ControllerBase
    {
        private readonly ITipoProcedimentoRepositorio _tipoProcedimentoRepositorio;

        public TipoProcedimentoController(ITipoProcedimentoRepositorio tipoProcedimentoRepositorio)
        {
            _tipoProcedimentoRepositorio = tipoProcedimentoRepositorio;
        }

        [HttpGet("GetAllTipoProcedimento")]
        public async Task<ActionResult<List<TipoProcedimentoModel>>> GetAllTipoProcedimento()
        {
            List<TipoProcedimentoModel> tipoProcedimento = await _tipoProcedimentoRepositorio.GetAll();
            return Ok(tipoProcedimento);
        }

        [HttpGet("GetTipoProcedimentoId/{id}")]
        public async Task<ActionResult<TipoProcedimentoModel>> GetTipoProcedimentoId(int id)
        {
            TipoProcedimentoModel tipoProcedimento = await _tipoProcedimentoRepositorio.GetById(id);
            return Ok(tipoProcedimento);
        }

        [HttpPost("CreateTipoProcedimento")]
        public async Task<ActionResult<TipoProcedimentoModel>> InsertTipoProcedimento([FromBody]TipoProcedimentoModel tipoProcedimentoModel)
        {
            TipoProcedimentoModel tipoProcedimento = await _tipoProcedimentoRepositorio.InsertTipoProcedimento(tipoProcedimentoModel);
            return Ok(tipoProcedimento);
        }

        [HttpPut("UpdateTipoProcedimento/{id:int}")]

        public async Task<ActionResult<TipoProcedimentoModel>> UpdateTipoProcedimento(int id, [FromBody] TipoProcedimentoModel tipoProcedimentoModel)
        {
            tipoProcedimentoModel.TipoProcedimentoId = id;
            TipoProcedimentoModel tipoProcedimento = await _tipoProcedimentoRepositorio.UpdateTipoProcedimento(tipoProcedimentoModel, id);
            return Ok(tipoProcedimento);
        }

        [HttpDelete("DeleteTipoProcedimento/{id:int}")]

        public async Task<ActionResult<TipoProcedimentoModel>> DeleteTipoProcedimento(int id)
        {
            bool deleted = await _tipoProcedimentoRepositorio.DeleteTipoProcedimento(id);
            return Ok(deleted);
        }

    }
}
