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
    public class AssinaturaClubeController : ControllerBase
    {
        private readonly IAssinaturaClubeRepositorio _assinaturaClubeRepositorio;

        public AssinaturaClubeController(IAssinaturaClubeRepositorio assinaturaClubeRepositorio)
        {
            _assinaturaClubeRepositorio = assinaturaClubeRepositorio;
        }

        [HttpGet("GetAllAssinaturaClube")]
        public async Task<ActionResult<List<AssinaturaClubeModel>>> GetAllAssinaturaClube()
        {
            List<AssinaturaClubeModel> assinaturaClube = await _assinaturaClubeRepositorio.GetAll();
            return Ok(assinaturaClube);
        }

        [HttpGet("GetAssinaturaClubeId/{id}")]
        public async Task<ActionResult<AssinaturaClubeModel>> GetAssinaturaClubeId(int id)
        {
            AssinaturaClubeModel assinaturaClube = await _assinaturaClubeRepositorio.GetById(id);
            return Ok(assinaturaClube);
        }

        [HttpPost("CreateAssinaturaClube")]
        public async Task<ActionResult<AssinaturaClubeModel>> InsertAssinaturaClube([FromBody]AssinaturaClubeModel assinaturaClubeModel)
        {
            AssinaturaClubeModel assinaturaClube = await _assinaturaClubeRepositorio.InsertAssinaturaClube(assinaturaClubeModel);
            return Ok(assinaturaClube);
        }

        [HttpPut("UpdateAssinaturaClube/{id:int}")]
        public async Task<ActionResult<AssinaturaClubeModel>> UpdateAssinaturaClube(int id, [FromBody] AssinaturaClubeModel assinaturaClubeModel)
        {
            assinaturaClubeModel.AssinaturaClubeId = id;
            AssinaturaClubeModel assinaturaClube = await _assinaturaClubeRepositorio.UpdateAssinaturaClube(assinaturaClubeModel, id);
            return Ok(assinaturaClube);
        }

        [HttpDelete("DeleteAssinaturaClube/{id:int}")]

        public async Task<ActionResult<AssinaturaClubeModel>> DeleteAssinaturaClube(int id)
        {
            bool deleted = await _assinaturaClubeRepositorio.DeleteAssinaturaClube(id);
            return Ok(deleted);
        }

    }
}
