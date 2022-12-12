using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoTurmaFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.ITurmaRepositorio _turmaRepositorio;

        public TurmaController(
            Projeto.Data.Interfaces.ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        [Route("/ListarTodas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.TurmaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_turmaRepositorio.ListarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/PorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.TurmaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            try
            {
                return Ok(_turmaRepositorio.PorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(AlunoCadastrarDto cadastrarDto)
        {
            return BadRequest();
        }

        [HttpPatch]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AlunoCadastrarDto cadastrarDto)
        {
            return BadRequest();
        }

        [HttpDelete]
        [Route("/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            return BadRequest();
        }

    }
}
