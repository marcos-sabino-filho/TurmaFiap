using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ListarTodas()
        {
            try
            {
                List<TurmaDto> resultado = _turmaRepositorio.ListarTodas();

                if (resultado == null)
                {
                    return NoContent();
                }

                if (resultado.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(resultado);
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

                if (resultado.Chave == 0)
                    throw new Exception("Não existe o id procurado na base de dados");

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
        [Route("/AtualizarTurma")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarTurma(AlunoCadastrarDto cadastrarDto)
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
