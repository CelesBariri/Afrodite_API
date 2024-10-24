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
    public class PagamentoAssinaturaController : ControllerBase
    {
        private readonly IPagamentoAssinaturaRepositorio _pagamentoAssinaturaRepositorio;

        public PagamentoAssinaturaController(IPagamentoAssinaturaRepositorio pagamentoAssinaturaRepositorio)
        {
            _pagamentoAssinaturaRepositorio = pagamentoAssinaturaRepositorio;
        }

        [HttpGet("GetAllPagamentoAssinatura")]
        public async Task<ActionResult<List<PagamentoAssinaturaModel>>> GetAllPagamentoAssinatura()
        {
            List<PagamentoAssinaturaModel> pagamentoAssinatura = await _pagamentoAssinaturaRepositorio.GetAll();
            return Ok(pagamentoAssinatura);
        }

        [HttpGet("GetPagamentoAssinaturaId/{id}")]
        public async Task<ActionResult<PagamentoAssinaturaModel>> GetPagamentoAssinaturaId(int id)
        {
            PagamentoAssinaturaModel pagamentoAssinatura = await _pagamentoAssinaturaRepositorio.GetById(id);
            return Ok(pagamentoAssinatura);
        }

        [HttpPost("CreatePagamentoAssinatura")]
        public async Task<ActionResult<PagamentoAssinaturaModel>> InsertPagamentoAssinatura([FromBody]PagamentoAssinaturaModel pagamentoAssinaturaModel)
        {
            PagamentoAssinaturaModel pagamentoAssinatura = await _pagamentoAssinaturaRepositorio.InsertPagamentoAssinatura(pagamentoAssinaturaModel);
            return Ok(pagamentoAssinatura);
        }

        [HttpPut("UpdatePagamentoAssinatura/{id:int}")]
        public async Task<ActionResult<PagamentoAssinaturaModel>> UpdatePagamentoAssinatura(int id, [FromBody] PagamentoAssinaturaModel pagamentoAssinaturaModel)
        {
            pagamentoAssinaturaModel.PagamentoAssinaturaId = id;
            PagamentoAssinaturaModel pagamentoAssinatura = await _pagamentoAssinaturaRepositorio.UpdatePagamentoAssinatura(pagamentoAssinaturaModel, id);
            return Ok(pagamentoAssinatura);
        }

        [HttpDelete("DeletePagamentoAssinatura/{id:int}")]

        public async Task<ActionResult<PagamentoAssinaturaModel>> DeletePagamentoAssinatura(int id)
        {
            bool deleted = await _pagamentoAssinaturaRepositorio.DeletePagamentoAssinatura(id);
            return Ok(deleted);
        }

    }
}
