using Projeto.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorio
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly Contexto.TreinamentoContext _contexto;

        public TurmaRepositorio(Contexto.TreinamentoContext contexto)
        {
            _contexto = contexto;
        }

        public List<Dto.TurmaDto> ListarTodas()
        {
            //return (from t in _contexto.Turmas
            //        select new Dto.TurmaDto()
            //        {
            //            Chave = t.Id,
            //            Nome = t.Nome
            //        }).ToList();

            return _contexto.Turmas.Select(s => new Dto.TurmaDto()
            {
                Chave = s.Id,
                Nome = s.Nome
            }).ToList();
        }

    }
}
