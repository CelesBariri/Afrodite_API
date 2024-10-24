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
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }

        [HttpGet("GetAllProfissional")]
        public async Task<ActionResult<List<ProfissionalModel>>> GetAllProfissional()
        {
            List<ProfissionalModel> profissional = await _profissionalRepositorio.GetAll();
            return Ok(profissional);
        }

        [HttpGet("GetUserId/{id}")]
        public async Task<ActionResult<ProfissionalModel>> GetUserId(int id)
        {
            ProfissionalModel profissional = await _profissionalRepositorio.GetById(id);
            return Ok(profissional);
        }

        [HttpPost("CreateProfissional")]
        public async Task<ActionResult<ProfissionalModel>> InsertProfissional([FromBody]ProfissionalModel profissionalModel)
        {
            ProfissionalModel profissional = await _profissionalRepositorio.InsertProfissional(profissionalModel);
            return Ok(profissional);
        }

        [HttpPut("UpdateProfissional/{id:int}")]

        public async Task<ActionResult<ProfissionalModel>> UpdateProfissional(int id, [FromBody] ProfissionalModel profissionalModel)
        {
            profissionalModel.ProfissionalId = id;
            ProfissionalModel profissional = await _profissionalRepositorio.UpdateProfissional(profissionalModel, id);
            return Ok(profissional);
        }

        [HttpDelete("DeleteProfissional/{id:int}")]

        public async Task<ActionResult<ProfissionalModel>> DeleteProfissional(int id)
        {
            bool deleted = await _profissionalRepositorio.DeleteProfissional(id);
            return Ok(deleted);
        }

    }
}
