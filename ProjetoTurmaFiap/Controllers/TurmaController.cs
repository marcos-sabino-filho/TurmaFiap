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
        [Route("/PorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.TurmaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                TurmaDto resultado = _turmaRepositorio.PorId(id);

                if (resultado == null)
                    return NoContent();

                return Ok(resultado);
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
            if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                return NoContent();

            return BadRequest();
        }

        [HttpPatch]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AlunoCadastrarDto cadastrarDto)
        {
            if (cadastrarDto == null || cadastrarDto.Id < 1)
                return NoContent();

            return BadRequest();
        }

        [HttpDelete]
        [Route("/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            if (id < 1)
                return NoContent();

            return BadRequest();
        }

    }
}
