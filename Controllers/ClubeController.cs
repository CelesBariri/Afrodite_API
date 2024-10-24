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
    public class ClubeController : ControllerBase
    {
        private readonly IClubeRepositorio _clubeRepositorio;

        public ClubeController(IClubeRepositorio clubeRepositorio)
        {
            _clubeRepositorio = clubeRepositorio;
        }

        [HttpGet("GetAllClube")]
        public async Task<ActionResult<List<ClubeModel>>> GetAllClube()
        {
            List<ClubeModel> clube = await _clubeRepositorio.GetAll();
            return Ok(clube);
        }

        [HttpGet("GetClubeId/{id}")]
        public async Task<ActionResult<ClubeModel>> GetClubeId(int id)
        {
            ClubeModel clube = await _clubeRepositorio.GetById(id);
            return Ok(clube);
        }

        [HttpPost("CreateClube")]
        public async Task<ActionResult<ClubeModel>> InsertUser([FromBody]ClubeModel userModel)
        {
            ClubeModel clube = await _clubeRepositorio.InsertClube(userModel);
            return Ok(clube);
        }

        [HttpPut("UpdateClube/{id:int}")]
        public async Task<ActionResult<ClubeModel>> UpdateClube(int id, [FromBody] ClubeModel clubeModel)
        {
            clubeModel.ClubeId = id;
            ClubeModel clube = await _clubeRepositorio.UpdateClube(clubeModel, id);
            return Ok(clube);
        }

        [HttpDelete("DeleteClube/{id:int}")]

        public async Task<ActionResult<ClubeModel>> DeleteClube(int id)
        {
            bool deleted = await _clubeRepositorio.DeleteClube(id);
            return Ok(deleted);
        }

    }
}
