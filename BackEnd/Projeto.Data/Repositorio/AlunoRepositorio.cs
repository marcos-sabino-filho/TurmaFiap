using Projeto.Data.Contexto;
using Projeto.Data.Dto;
using Projeto.Data.Entidades;
using Projeto.Data.Interfaces;

namespace Projeto.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly TreinamentoContext _treinamentoContexto;

        public AlunoRepositorio(TreinamentoContext treinamentoContexto)
        {
            _treinamentoContexto = treinamentoContexto;
        }

        public int Atualizar(AlunoCadastrarDto cadastrarDto)
        {
            throw new NotImplementedException();
        }

        public int Cadastrar(AlunoCadastrarDto cadastrarDto)
        {
            throw new NotImplementedException();
        }

        public int Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ListarTodos()
        {
            return _treinamentoContexto.Alunos.ToList();
        }

        public Aluno PorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
