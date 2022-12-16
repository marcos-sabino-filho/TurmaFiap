using Projeto.Data.Entidades;
using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class TurmaAlunosRepositorio : IturmaAlunosRepositorio
    {
        private readonly Contexto.TreinamentoContext _contexto;

        public TurmaAlunosRepositorio(Contexto.TreinamentoContext contexto)
        {
            _contexto = contexto;
        }

        public int Associar(TurmaAluno turmaAluno)
        {
            _contexto.ChangeTracker.Clear();
            _contexto.TurmaAlunos.Add(turmaAluno);
            return _contexto.SaveChanges();
        }
    }
}
