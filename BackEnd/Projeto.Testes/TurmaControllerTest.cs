using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Projeto.Testes
{
    [TestClass]
    public class TurmaControllerTest
    {
        Mock<Projeto.Data.Contexto.TreinamentoContext> _treinamentoContext;
        public TurmaControllerTest()
        {
            _treinamentoContext = new Mock<Data.Contexto.TreinamentoContext>();
        }

        #region [ Método Listar Todas ]

        [TestMethod]
        public void ListarTodasAsTurmas_SemConteudo()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as NoContentResult;

            Assert.AreEqual(204, resultadoControllerReal.StatusCode);
        }

        [TestMethod]
        public void ListarTodasAsTurmas_BadRequest()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Data.Dto.TurmaDto>()
                {

                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as BadRequestObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(400, resultadoControllerReal.StatusCode);
        }

        [TestMethod]
        public void ListarTodasAsTurmas_ComApenasUmElemento()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Data.Dto.TurmaDto>()
                {
                    new Data.Dto.TurmaDto()
                    {
                        Chave = 77,
                        Nome = "F#"
                    },
                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(200, resultadoControllerReal.StatusCode);

            List<Data.Dto.TurmaDto> listarTodas =
                resultadoControllerReal.Value as List<Data.Dto.TurmaDto>;

            Assert.IsNotNull(listarTodas);
            Assert.AreEqual(1, listarTodas.Count);
            Assert.AreEqual(77, listarTodas[0].Chave);
        }

        [TestMethod]
        public void ListarTodasAsTurmas_ComMaisDeUmElemento()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Data.Dto.TurmaDto>()
                {
                    new Data.Dto.TurmaDto()
                    {
                        Chave = 77,
                        Nome = "F#"
                    },
                    new Data.Dto.TurmaDto()
                    {
                        Chave = 88,
                        Nome = "C#"
                    }
                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(200, resultadoControllerReal.StatusCode);

            List<Data.Dto.TurmaDto> listarTodas =
                resultadoControllerReal.Value as List<Data.Dto.TurmaDto>;

            Assert.IsNotNull(listarTodas);
            Assert.AreEqual(2, listarTodas.Count);
            Assert.AreEqual(77, listarTodas[0].Chave);
            Assert.AreEqual("C#", listarTodas[1].Nome);

        }

        #endregion

        #region [ Por Id ]

        [TestMethod]
        public void PorId_SemResultado()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            IActionResult resultadoController = turmaController.PorId(0);

            var resultadoControllerReal = resultadoController as NoContentResult;

            Assert.AreEqual(204, resultadoControllerReal.StatusCode);
        }

        [TestMethod]
        public void PorId_ComApenasUmResultado()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.PorId(1))
                .Returns(new Data.Dto.TurmaDto()
                {
                    Chave = 77,
                    Nome = "F#"
                });

            IActionResult resultadoController = turmaController.PorId(1);

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(200, resultadoControllerReal.StatusCode);

            Data.Dto.TurmaDto listarTodas =
                resultadoControllerReal.Value as Data.Dto.TurmaDto;

            Assert.IsNotNull(listarTodas);
            Assert.AreEqual(77, listarTodas.Chave);
        }

        [TestMethod]
        public void PorId_ComParametroDeEntradaGenerico()
        {
            Mock<Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.PorId(It.IsAny<int>()))
                .Returns(new Data.Dto.TurmaDto()
                {
                    Chave = 77,
                    Nome = "F#"
                });

            IActionResult resultadoController = turmaController.PorId(999999);

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(200, resultadoControllerReal.StatusCode);

            Data.Dto.TurmaDto listarTodas =
                resultadoControllerReal.Value as Data.Dto.TurmaDto;

            Assert.IsNotNull(listarTodas);
            Assert.AreEqual(77, listarTodas.Chave);
        }

        [TestMethod]
        public void PorId_ConsultandoTabelaEntityMockada()
        {
            int idParaPesquisar = 3;

            #region [ CONFIGURACAO DE TABELA ]

            IQueryable<Projeto.Data.Entidades.Turma> data = new List<Projeto.Data.Entidades.Turma>
            {
                new Data.Entidades.Turma()
                {
                    Id = 1,
                    Nome = "C#",
                    Descricao = "Incrições abertas para a turma de c#"
                },
                new Data.Entidades.Turma()
                {
                    Id = 2,
                    Nome = "Java",
                    Descricao = "Treinamento com Java"
                },
                new Data.Entidades.Turma()
                {
                    Id = 3,
                    Nome = "API",
                    Descricao = "Treinamento com API"
                }
            }.AsQueryable();

            var mockTabela = new Mock<DbSet<Projeto.Data.Entidades.Turma>>();
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.Provider).Returns(data.Provider);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.Expression).Returns(data.Expression);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockTabela.As<IQueryable<Projeto.Data.Entidades.Turma>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _treinamentoContext.Setup(x => x.Turmas).Returns(mockTabela.Object);

            #endregion

            Data.Repositorio.TurmaRepositorio turmaRepositorio =
                new Data.Repositorio.TurmaRepositorio(_treinamentoContext.Object);

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio);

            IActionResult resultadoController = turmaController.PorId(idParaPesquisar);

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.IsNotNull(resultadoControllerReal);
            Assert.AreEqual(200, resultadoControllerReal.StatusCode);

            Data.Dto.TurmaDto listarTodas =
                resultadoControllerReal.Value as Data.Dto.TurmaDto;

            Assert.IsNotNull(listarTodas);
            Assert.AreEqual(idParaPesquisar, listarTodas.Chave);
        }

        #endregion
    }
}