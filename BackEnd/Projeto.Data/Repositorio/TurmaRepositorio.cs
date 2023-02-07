using Projeto.Data.Contexto;
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
            Entidades.Turma turmaEntidadeBanco =
                (from c in _contexto.Turmas
                 where c.Id == cadastrarDto.Id
                 select c)
                 ?.FirstOrDefault()
                 ?? new Entidades.Turma();

            if (DBNull.Value.Equals(turmaEntidadeBanco.Nome))
            {
                // entra aqui
            }

            if (turmaEntidadeBanco.Nome == null)
            {
                // entra aqui
            }

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (turmaEntidadeBanco == null || DBNull.Value.Equals(turmaEntidadeBanco.Id) || turmaEntidadeBanco.Id == 0)
            {
                return 0;
            }

            Entidades.Turma turmaEntidade = new Entidades.Turma()
            {
                Nome = cadastrarDto.Nome,
                Descricao = cadastrarDto.Descricao,
                PeriodoInicio = cadastrarDto.PeriodoInicio,
                PeriodoFim = cadastrarDto.PeriodoFim
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Add(turmaEntidade);
            return _contexto.SaveChanges();
        }

        public int Cadastrar(TurmaCadastrarDto cadastrarDto)
        {
            Entidades.Turma turmaEntidade = new Entidades.Turma()
            {
                Nome = cadastrarDto.Nome,
                Descricao = cadastrarDto.Descricao,
                PeriodoInicio = cadastrarDto.PeriodoInicio,
                PeriodoFim = cadastrarDto.PeriodoFim
            };

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Add(turmaEntidade);
            return _contexto.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Entidades.Turma turmaEntidadeBanco =
                (from c in _contexto.Turmas
                 where c.Id == Id
                 select c).FirstOrDefault();

            // TRATAMENTO DE ERRO
            // CASO NÃO ACHE O ID PARA ATUALIZAR, RETORNA VALOR 0. 
            // OU SEJA, NÃO ATUALIZOU NENHUM CADASTRO
            if (turmaEntidadeBanco == null || DBNull.Value.Equals(turmaEntidadeBanco.Id) || turmaEntidadeBanco.Id == 0)
            {
                return 0;
            }

            _contexto.ChangeTracker.Clear();
            _contexto.Turmas.Remove(turmaEntidadeBanco);
            return _contexto.SaveChanges();
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
            return (from t in _contexto.Turmas
                    where t.Id == id
                    select new Dto.TurmaDto()
                    {
                        Chave = t.Id,
                        Nome = t.Nome
                    })
                    ?.FirstOrDefault()
                    ?? new TurmaDto();
        }
    }
}
