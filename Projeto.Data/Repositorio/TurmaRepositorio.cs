using Projeto.Data.Dto;
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

        public int Atualizar(TurmaCadastrarDto cadastrarDto)
        {
            throw new NotImplementedException();
        }

        public int Cadastrar(TurmaCadastrarDto cadastrarDto)
        {
            throw new NotImplementedException();
        }

        public int Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Dto.TurmaDto> ListarTodas()
        {
            return _contexto.Turmas.Select(s => new Dto.TurmaDto()
            {
                Chave = s.Id,
                Nome = s.Nome
            }).ToList();
        }

        public TurmaDto PorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
