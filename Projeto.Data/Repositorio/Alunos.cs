using Projeto.Data.Contexto;
using Projeto.Data.Entidades;
using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class Alunos : IAlunos
    {
        private readonly TreinamentoContext _treinamentoContexto;

        public Alunos(TreinamentoContext treinamentoContexto)
        {
            _treinamentoContexto = treinamentoContexto;
        }

        public List<Aluno> ListarTodos()
        {
            return _treinamentoContexto.Alunos.ToList();
        }
    }
}
