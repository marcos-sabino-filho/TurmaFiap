using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Net.Sockets;

namespace Projeto.Testes
{
    [TestClass]
    public class UnitTest1
    {

        Mock<Projeto.Data.Contexto.TreinamentoContext> _treinamentoContext;

        public UnitTest1()
        {
            _treinamentoContext = new Mock<Data.Contexto.TreinamentoContext>();
        }

        [TestMethod]
        public void ListaTodosOsAlunos()
        {
            #region [ CONFIGURACAO ]

            IQueryable<Projeto.Data.Entidades.Aluno> data = new List<Projeto.Data.Entidades.Aluno>
            {
                new Data.Entidades.Aluno()
                {
                    Id = 1,
                    Nome = "Marcos",
                    Documento = "1123123",
                    Matricula = "123123"
                },
                new Data.Entidades.Aluno()
                {
                    Id = 2,
                    Nome = "José",
                    Documento = "31312312",
                    Matricula = "12"
                }
            }.AsQueryable();

            var mockTabela = new Mock<DbSet<Projeto.Data.Entidades.Aluno>>();
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Aluno>>().Setup(m => m.Provider).Returns(data.Provider);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Aluno>>().Setup(m => m.Expression).Returns(data.Expression);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Aluno>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Aluno>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _treinamentoContext.Setup(x => x.Alunos).Returns(mockTabela.Object);

            #endregion

            Projeto.Data.Repositorio.AlunoRepositorio alunosRepo =
                new Data.Repositorio.AlunoRepositorio(_treinamentoContext.Object);

            List<Projeto.Data.Entidades.Aluno> listaAlunos =
                alunosRepo.ListarTodos();

            Assert.IsTrue(listaAlunos.Count() == 2);
            Assert.AreEqual(1, listaAlunos[0].Id);
        }

        [TestMethod]
        public void ListarTodasAsTurmasController()
        {
            #region [ CONFIGURACAO ]

            IQueryable<Projeto.Data.Entidades.Turma> data = new List<Projeto.Data.Entidades.Turma>
            {
                new Data.Entidades.Turma()
                {
                    Id = 1,
                    Nome = "C#",
                    Descricao = ""
                },
                new Data.Entidades.Turma()
                {
                    Id = 2,
                    Nome = "Java",
                    Descricao = "Decola Dev Java"
                },
                new Data.Entidades.Turma()
                {
                    Id = 3,
                    Nome = "API",
                    Descricao = "Decola Dev API"
                }
            }.AsQueryable();

            var mockTabela = new Mock<DbSet<Projeto.Data.Entidades.Turma>>();
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.Provider).Returns(data.Provider);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.Expression).Returns(data.Expression);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _treinamentoContext.Setup(x => x.Turmas).Returns(mockTabela.Object);

            #endregion

            Projeto.Data.Repositorio.TurmaRepositorio turmaRepositorio
                = new Data.Repositorio.TurmaRepositorio(_treinamentoContext.Object);

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio);

            IActionResult actionResult = turmaController.ListarTodas();

            var resultado = actionResult as OkObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(200, resultado.StatusCode);

            List<Data.Dto.TurmaDto> listaResultado =
                resultado.Value as List<Data.Dto.TurmaDto>;

            Assert.IsNotNull(listaResultado);
            Assert.AreEqual(3, listaResultado.Count);
            Assert.AreEqual(2, listaResultado[1].Chave);
        }

        [TestMethod]
        public void ListarTodasAsTurmasController_Simples()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio
                = new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Data.Dto.TurmaDto>()
                {
                    new Data.Dto.TurmaDto()
                    {
                        Chave = 5,
                        Nome = "F#"
                    },
                    new Data.Dto.TurmaDto()
                    {
                        Chave = 6,
                        Nome = "Lambda"
                    }
                });

            IActionResult actionResult = turmaController.ListarTodas();

            var resultado = actionResult as OkObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(200, resultado.StatusCode);

            List<Data.Dto.TurmaDto> listaResultado =
                resultado.Value as List<Data.Dto.TurmaDto>;

            Assert.IsNotNull(listaResultado);
            Assert.AreEqual(2, listaResultado.Count);
            Assert.AreEqual(6, listaResultado[1].Chave);
        }

        [TestMethod]
        public void ListarTodasAsTurmasController_BadRequest()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio
                = new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Data.Dto.TurmaDto>()
                {
                });

            IActionResult actionResult = turmaController.ListarTodas();

            var resultado = actionResult as BadRequestObjectResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(400, resultado.StatusCode);

            string resultadoApi =
                resultado.Value as string;

            Assert.IsNotNull(resultadoApi);
            Assert.AreEqual("Sem elementos", resultadoApi);
        }

        [TestMethod]
        public void ListarTodasAsTurmasController_BadRequestNulo()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio
                = new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns((List<Data.Dto.TurmaDto>)null);

            IActionResult actionResult = turmaController.ListarTodas();

            var resultado = actionResult as NoContentResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(204, resultado.StatusCode);
        }
    }
}