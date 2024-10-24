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
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;

        public AgendamentoController(IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        [HttpGet("GetAllAgendamento")]
        public async Task<ActionResult<List<AgendamentoModel>>> GetAllAgendamento()
        {
            List<AgendamentoModel> agendamento = await _agendamentoRepositorio.GetAll();
            return Ok(agendamento);
        }

        [HttpGet("GetAgendamentoId/{id}")]
        public async Task<ActionResult<AgendamentoModel>> GetAgendamentoId(int id)
        {
            AgendamentoModel agendamento = await _agendamentoRepositorio.GetById(id);
            return Ok(agendamento);
        }

        [HttpPost("CreateAgendamento")]
        public async Task<ActionResult<AgendamentoModel>> InsertAgendamento([FromBody]AgendamentoModel agendamentoModel)
        {
            AgendamentoModel agendamento = await _agendamentoRepositorio.InsertAgendamento(agendamentoModel);
            return Ok(agendamento);
        }
        
        [HttpPut("UpdateAgendamento/{id:int}")]
        public async Task<ActionResult<AgendamentoModel>> UpdateAgendamento(int id, [FromBody] AgendamentoModel agendamentoModel)
        {
            agendamentoModel.AgendamentoId = id;
            AgendamentoModel agendamento = await _agendamentoRepositorio.UpdateAgendamento(agendamentoModel, id);
            return Ok(agendamento);
        }

        [HttpDelete("DeleteAgendamento/{id:int}")]

        public async Task<ActionResult<AgendamentoModel>> DeleteAgendamento(int id)
        {
            bool deleted = await _agendamentoRepositorio.DeleteAgendamento(id);
            return Ok(deleted);
        }

    }
}
