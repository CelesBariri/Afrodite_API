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
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public FormaPagamentoController(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        [HttpGet("GetAllFormaPagamento")]
        public async Task<ActionResult<List<FormaPagamentoModel>>> GetAllFormaPagamento()
        {
            List<FormaPagamentoModel> formaPagamento = await _formaPagamentoRepositorio.GetAll();
            return Ok(formaPagamento);
        }

        [HttpGet("GetFormaPagamentoId/{id}")]
        public async Task<ActionResult<FormaPagamentoModel>> GetFormaPagamentoId(int id)
        {
            FormaPagamentoModel formaPagamento = await _formaPagamentoRepositorio.GetById(id);
            return Ok(formaPagamento);
        }

        [HttpPost("CreateFormaPagamento")]
        public async Task<ActionResult<FormaPagamentoModel>> InsertFormaPagamento([FromBody]FormaPagamentoModel formaPagamentoModel)
        {
            FormaPagamentoModel formaPagamento = await _formaPagamentoRepositorio.InsertFormaPagamento(formaPagamentoModel);
            return Ok(formaPagamento);
        }

        [HttpPut("UpdateFormaPagemento/{id:int}")]
        public async Task<ActionResult<FormaPagamentoModel>> UpdateFormaPagamento(int id, [FromBody] FormaPagamentoModel formaPagamentoModel)
        {
            formaPagamentoModel.FormaPagamentoId = id;
            FormaPagamentoModel formaPagamento = await _formaPagamentoRepositorio.UpdateFormaPagamento(formaPagamentoModel, id);
            return Ok(formaPagamento);
        }

        [HttpDelete("DeleteFormaPagamento/{id:int}")]

        public async Task<ActionResult<FormaPagamentoModel>> DeleteFormaPagamento(int id)
        {
            bool deleted = await _formaPagamentoRepositorio.DeleteFormaPagamento(id);
            return Ok(deleted);
        }

    }
}
