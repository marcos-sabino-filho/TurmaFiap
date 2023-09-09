﻿namespace Projeto.Data.Interfaces
{
    public interface IAlunoRepositorio
    {
        public List<Entidades.Aluno> ListarTodos();

        Entidades.Aluno PorId(int id);

        int Cadastrar(Dto.AlunoCadastrarDto cadastrarDto);

        int Atualizar(Dto.AlunoCadastrarDto cadastrarDto);

        int Excluir(int Id);
    }
}
