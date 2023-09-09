namespace Projeto.Testes
{
    [TestClass]
    public class RepositorioAlunos
    {

        public RepositorioAlunos()
        {
        }

        [TestMethod]
        public void TestarMetodoSomar()
        {
            Projeto.Data.Metodos metodos = new Data.Metodos();
            int resultado = metodos.Somar(1, 2);

            Assert.AreEqual(resultado, 3);
        }

        [TestMethod]
        public void TestarInsertNoBanco()
        {
            // instanciar uma classe de repositorio do projeto data
            // chamo o metodo de insercao
            // valido se o registo esta no banco
        }

        /// <summary>
        /// Descricao do método
        /// </summary>
        [TestMethod]
        public void ListarTodosComResultado()
        {

        }

        [TestMethod]
        public void ListarTodosSemResultado()
        {

        }

    }
}
