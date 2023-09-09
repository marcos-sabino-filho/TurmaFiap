namespace Projeto.Data.Interfaces
{
    public interface ITurmaRepositorio
    {
        List<Dto.TurmaDto> ListarTodas();

        Dto.TurmaDto PorId(int id);

        int Cadastrar(Dto.TurmaCadastrarDto cadastrarDto);

        int Atualizar(Dto.TurmaCadastrarDto cadastrarDto);

        int Excluir(int Id);
    }
}
