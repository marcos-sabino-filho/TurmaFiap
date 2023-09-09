namespace Projeto.Data.Dto
{
    public class TurmaCadastrarDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public DateTime PeriodoInicio { get; set; }

        public DateTime PeriodoFim { get; set; }
    }
}
