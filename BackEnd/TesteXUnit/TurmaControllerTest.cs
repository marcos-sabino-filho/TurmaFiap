
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TesteXUnit
{
    public class TurmaControllerTest
    {
        Mock<Projeto.Data.Contexto.TreinamentoContext> _treinamentoContext;
        public TurmaControllerTest()
        {
            _treinamentoContext = new Mock<Projeto.Data.Contexto.TreinamentoContext>();
        }

        [Fact]
        public void ListarTodasAsTurmas_SemConteudo()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Projeto.Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as NoContentResult;

            Assert.Equal(204, resultadoControllerReal.StatusCode);
        }

        [Fact]
        public void ListarTodasAsTurmas_BadRequest()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Projeto.Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Projeto.Data.Dto.TurmaDto>()
                {

                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as BadRequestObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(400, resultadoControllerReal.StatusCode);
        }

        [Fact]
        public void ListarTodasAsTurmas_ComApenasUmElemento()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Projeto.Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Projeto.Data.Dto.TurmaDto>()
                {
                    new Projeto.Data.Dto.TurmaDto()
                    {
                        Chave = 77,
                        Nome = "F#"
                    },
                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(200, resultadoControllerReal.StatusCode);

            List<Projeto.Data.Dto.TurmaDto> listarTodas =
                resultadoControllerReal.Value as List<Projeto.Data.Dto.TurmaDto>;

            Assert.NotNull(listarTodas);
            Assert.Equal(1, listarTodas.Count);
            Assert.Equal(77, listarTodas[0].Chave);
        }

        [Fact]
        public void ListarTodasAsTurmas_ComMaisDeUmElemento()
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Projeto.Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.ListarTodas())
                .Returns(new List<Projeto.Data.Dto.TurmaDto>()
                {
                    new Projeto.Data.Dto.TurmaDto()
                    {
                        Chave = 77,
                        Nome = "F#"
                    },
                    new Projeto.Data.Dto.TurmaDto()
                    {
                        Chave = 88,
                        Nome = "C#"
                    }
                });

            IActionResult resultadoController = turmaController.ListarTodas();

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(200, resultadoControllerReal.StatusCode);

            List<Projeto.Data.Dto.TurmaDto> listarTodas =
                resultadoControllerReal.Value as List<Projeto.Data.Dto.TurmaDto>;

            Assert.NotNull(listarTodas);
            Assert.Equal(2, listarTodas.Count);
            Assert.Equal(77, listarTodas[0].Chave);
            Assert.Equal("C#", listarTodas[1].Nome);

        }

        [Theory]
        [InlineData(1, 77)]
        [InlineData(2, 77)]
        [InlineData(9, 77)]
        [InlineData(9999, 77)]
        public void PorId_ComApenasUmResultado(int idEntrada, int resultadoEsperado)
        {
            Mock<Projeto.Data.Interfaces.ITurmaRepositorio> turmaRepositorio =
                new Mock<Projeto.Data.Interfaces.ITurmaRepositorio>();

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio.Object);

            turmaRepositorio.Setup(s => s.PorId(It.IsAny<int>()))
                .Returns(new Projeto.Data.Dto.TurmaDto()
                {
                    Chave = 77,
                    Nome = "F#"
                });

            IActionResult resultadoController = turmaController.PorId(idEntrada);

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(200, resultadoControllerReal.StatusCode);

            Projeto.Data.Dto.TurmaDto listarTodas =
                resultadoControllerReal.Value as Projeto.Data.Dto.TurmaDto;

            Assert.NotNull(listarTodas);
            Assert.Equal(resultadoEsperado, listarTodas.Chave);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void PorId_ConsultandoTabelaEntityMockada(int idEntrada, int resultadoEsperado)
        {

            #region [ CONFIGURACAO DE TABELA ]

            IQueryable<Projeto.Data.Entidades.Turma> data = new List<Projeto.Data.Entidades.Turma>
            {
                new Projeto.Data.Entidades.Turma()
                {
                    Id = 1,
                    Nome = "C#",
                    Descricao = "Incrições abertas para a turma de c#"
                },
                new Projeto.Data.Entidades.Turma()
                {
                    Id = 2,
                    Nome = "Java",
                    Descricao = "Treinamento com Java"
                },
                new Projeto.Data.Entidades.Turma()
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

            Projeto.Data.Repositorio.TurmaRepositorio turmaRepositorio =
                new Projeto.Data.Repositorio.TurmaRepositorio(_treinamentoContext.Object);

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio);

            IActionResult resultadoController = turmaController.PorId(idEntrada);

            var resultadoControllerReal = resultadoController as OkObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(200, resultadoControllerReal.StatusCode);

            Projeto.Data.Dto.TurmaDto listarTodas =
                resultadoControllerReal.Value as Projeto.Data.Dto.TurmaDto;

            Assert.NotNull(listarTodas);
            Assert.Equal(resultadoEsperado, listarTodas.Chave);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(99)]
        public void PorId_ConsultandoTabelaEntityMockadaBadRequest(int idEntrada)
        {
            #region [ CONFIGURACAO DE TABELA ]

            IQueryable<Projeto.Data.Entidades.Turma> data = new List<Projeto.Data.Entidades.Turma>
            {
                new Projeto.Data.Entidades.Turma()
                {
                    Id = 1,
                    Nome = "C#",
                    Descricao = "Incrições abertas para a turma de c#"
                },
                new Projeto.Data.Entidades.Turma()
                {
                    Id = 2,
                    Nome = "Java",
                    Descricao = "Treinamento com Java"
                },
                new Projeto.Data.Entidades.Turma()
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

            Projeto.Data.Repositorio.TurmaRepositorio turmaRepositorio =
                new Projeto.Data.Repositorio.TurmaRepositorio(_treinamentoContext.Object);

            ProjetoTurmaFiap.Controllers.TurmaController turmaController =
                new ProjetoTurmaFiap.Controllers.TurmaController(turmaRepositorio);

            IActionResult resultadoController = turmaController.PorId(idEntrada);

            var resultadoControllerReal = resultadoController as BadRequestObjectResult;

            Assert.NotNull(resultadoControllerReal);
            Assert.Equal(400, resultadoControllerReal.StatusCode);
        }

    }
}