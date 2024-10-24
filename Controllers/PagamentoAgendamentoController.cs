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
    public class PagamentoAgendamentoController : ControllerBase
    {
        private readonly IPagamentoAgendamentoRepositorio _pagamentoAgendamentoRepositorio;

        public PagamentoAgendamentoController(IPagamentoAgendamentoRepositorio pagamentoAgendamentoRepositorio)
        {
            _pagamentoAgendamentoRepositorio = pagamentoAgendamentoRepositorio;
        }

        [HttpGet("GetAllPagamentoAgendamento")]
        public async Task<ActionResult<List<PagamentoAgendamentoModel>>> GetAllPagamentoAgendamento()
        {
            List<PagamentoAgendamentoModel> pagamentoAgendamento = await _pagamentoAgendamentoRepositorio.GetAll();
            return Ok(pagamentoAgendamento);
        }

        [HttpGet("GetPagamentoAgendamentoId/{id}")]
        public async Task<ActionResult<PagamentoAgendamentoModel>> GetPagamentoAgendamentoId(int id)
        {
            PagamentoAgendamentoModel pagamentoAgendamento = await _pagamentoAgendamentoRepositorio.GetById(id);
            return Ok(pagamentoAgendamento);
        }

        [HttpPost("CreatePagamentoAgendamento")]
        public async Task<ActionResult<PagamentoAgendamentoModel>> InsertPagamentoAgendamento([FromBody]PagamentoAgendamentoModel pagamentoAgendamentoModel)
        {
            PagamentoAgendamentoModel pagamentoAgendamento = await _pagamentoAgendamentoRepositorio.InsertPagamentoAgendamento(pagamentoAgendamentoModel);
            return Ok(pagamentoAgendamento);
        }

        [HttpPut("UpdatePagamentoAgendamento/{id:int}")]
        public async Task<ActionResult<PagamentoAgendamentoModel>> UpdatePagamentoAgendamento(int id, [FromBody] PagamentoAgendamentoModel pagamentoAgendamentoModel)
        {
            pagamentoAgendamentoModel.PagamentoAgendamentoId = id;
            PagamentoAgendamentoModel pagamentoAgendamento = await _pagamentoAgendamentoRepositorio.UpdatePagamentoAgendamento(pagamentoAgendamentoModel, id);
            return Ok(pagamentoAgendamento);
        }

        [HttpDelete("DeletePagamentoAgendamento/{id:int}")]

        public async Task<ActionResult<PagamentoAgendamentoModel>> DeletePagamentoAgendamento(int id)
        {
            bool deleted = await _pagamentoAgendamentoRepositorio.DeletePagamentoAgendamento(id);
            return Ok(deleted);
        }

    }
}
