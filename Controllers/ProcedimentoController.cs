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
    public class ProcedimentoController : ControllerBase
    {
        private readonly IProcedimentoRepositorio _procedimentoRepositorio;

        public ProcedimentoController(IProcedimentoRepositorio procedimentoRepositorio)
        {
            _procedimentoRepositorio = procedimentoRepositorio;
        }

        [HttpGet("GetAllProcedimento")]
        public async Task<ActionResult<List<ProcedimentoModel>>> GetAllProcedimento()
        {
            List<ProcedimentoModel> procedimento = await _procedimentoRepositorio.GetAll();
            return Ok(procedimento);
        }

        [HttpGet("GetProcedimentoId/{id}")]
        public async Task<ActionResult<ProcedimentoModel>> GetProcedimentoId(int id)
        {
            ProcedimentoModel procedimento = await _procedimentoRepositorio.GetById(id);
            return Ok(procedimento);
        }

        [HttpPost("CreateProcedimento")]
        public async Task<ActionResult<ProcedimentoModel>> InsertProcedimento([FromBody]ProcedimentoModel procedimentoModel)
        {
            ProcedimentoModel procedimento = await _procedimentoRepositorio.InsertProcedimento(procedimentoModel);
            return Ok(procedimento);
        }

        [HttpPut("UpdateProcedimento/{id:int}")]
        public async Task<ActionResult<ProcedimentoModel>> UpdateProcedimento(int id, [FromBody] ProcedimentoModel procedimentoModel)
        {
            procedimentoModel.ProcedimentoId = id;
            ProcedimentoModel procedimento = await _procedimentoRepositorio.UpdateProcedimento(procedimentoModel, id);
            return Ok(procedimento);
        }

        [HttpDelete("DeleteProcedimento/{id:int}")]

        public async Task<ActionResult<ProcedimentoModel>> DeleteProcedimento(int id)
        {
            bool deleted = await _procedimentoRepositorio.DeleteProcedimento(id);
            return Ok(deleted);
        }

    }
}
