using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ProjetoTurmaFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AlunosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Entidades.Aluno>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            List<Projeto.Data.Entidades.Aluno> alunos = new List<Projeto.Data.Entidades.Aluno>();

            try
            {
                string strConexao = _configuration.GetConnectionString("Sql");

                using (SqlConnection connection = new SqlConnection(strConexao))
                {
                    connection.Open();

                    StringBuilder strComando = new StringBuilder();
                    strComando.AppendLine("SELECT [Id]");
                    strComando.AppendLine("      ,[Nome]");
                    strComando.AppendLine("      ,[UltimoNome]");
                    strComando.AppendLine("      ,[Aniversario]");
                    strComando.AppendLine("      ,[Documento]");
                    strComando.AppendLine("      ,[Matricula]");
                    strComando.AppendLine("  FROM [dbo].[Alunos]");

                    using (SqlCommand cmd = new SqlCommand(strComando.ToString(), connection))
                    {
                        SqlDataReader retornoSelect = cmd.ExecuteReader();

                        while (retornoSelect.Read())
                        {
                            alunos.Add(new Projeto.Data.Entidades.Aluno()
                            {
                                Id = Convert.ToInt32(retornoSelect["Id"] ?? "0"),
                                Nome = TratarNulo(retornoSelect["Nome"]),
                                UltimoNome = TratarNulo(retornoSelect["UltimoNome"]),
                                Matricula = TratarNulo(retornoSelect["Matricula"]),
                                Documento = TratarNulo(retornoSelect["Documento"]),
                                Aniversario = Convert.ToDateTime(
                                    retornoSelect["Aniversario"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : retornoSelect["Aniversario"])
                            });
                        }
                    }
                }

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/ListarTodosDapper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Entidades.Aluno>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodosDapper()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine("SELECT [Id]");
                strComando.AppendLine("      ,[Nome]");
                strComando.AppendLine("      ,[UltimoNome]");
                strComando.AppendLine("      ,[Aniversario]");
                strComando.AppendLine("      ,[Documento]");
                strComando.AppendLine("      ,[Matricula]");
                strComando.AppendLine("  FROM [dbo].[Alunos]");

                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));
                List<Projeto.Data.Entidades.Aluno> alunos = connection.Query<Projeto.Data.Entidades.Aluno>(strComando.ToString()).ToList();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string TratarNulo(object valor)
        {
            if (valor == DBNull.Value)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(valor);
            }
        }

        [HttpGet]
        [Route("/ListarPorId/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Entidades.Aluno))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int Id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Id);

                Projeto.Data.Entidades.Aluno aluno =
                    connection.Query<Projeto.Data.Entidades.Aluno>(
                        "Select Id,Nome from Alunos where Id = @Id",
                        dynamicParameters
                        ).FirstOrDefault();
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CadastrarAluno")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarAluno(Projeto.Data.Entidades.Aluno aluno)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                if (aluno.Aniversario == DateTime.MinValue)
                    aluno.Aniversario = null;

                int linhasAfetadas = connection.Execute(
                      "INSERT INTO [dbo].[Alunos] " +
                      "([Nome],[UltimoNome],[Aniversario],[Documento],[Matricula])" +
                      "     VALUES(@Nome,@UltimoNome,@Aniversario,@Documento,@Matricula)", aluno);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Projeto.Data.Entidades.Aluno aluno)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                if (aluno.Aniversario == DateTime.MinValue)
                    aluno.Aniversario = null;

                int linhasAfetadas = connection.Execute(
                      "DELETE FROM [dbo].[Alunos] WHERE Id = @Id", aluno);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(Projeto.Data.Entidades.Aluno aluno)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                if (aluno.Aniversario == DateTime.MinValue)
                    aluno.Aniversario = null;

                int linhasAfetadas = connection.Execute(
                      "UPDATE [dbo].[Alunos]" +
                      "   SET[Nome] = @Nome" +
                      "      ,[UltimoNome] = @UltimoNome" +
                      "      ,[Aniversario] = @Aniversario" +
                      "      ,[Documento] = @Documento" +
                      "      ,[Matricula] = @Matricula" +
                      " WHERE Id = @Id", aluno);

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
