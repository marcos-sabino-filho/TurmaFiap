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

            _treinamentoContext.Setup(x=>x.Alunos).Returns(mockTabela.Object);

            #endregion

            Projeto.Data.Repositorio.AlunoRepositorio alunosRepo =
                new Data.Repositorio.AlunoRepositorio(_treinamentoContext.Object);

            List<Projeto.Data.Entidades.Aluno> listaAlunos =
                alunosRepo.ListarTodos();

            Assert.IsTrue(listaAlunos.Count() == 2);
            Assert.AreEqual(1, listaAlunos[0].Id);
        }
    }
}