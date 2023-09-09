using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Interfaces;
namespace ProjetoTurmaFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class turmaAlunosController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IturmaAlunosRepositorio _turmaRepositorio;

        public turmaAlunosController(IturmaAlunosRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpPost]
        [Route("/AssociarAlunos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AssociarAluno(Projeto.Data.Entidades.TurmaAluno aluno)
        {
            try
            {
                int retorno = _turmaRepositorio.Associar(aluno);

                if (retorno > 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
