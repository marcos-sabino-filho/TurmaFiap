using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class Turma
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateTime PeriodoInicio { get; set; }

    public DateTime PeriodoFim { get; set; }

    public virtual ICollection<TurmaAluno> TurmaAlunos { get; } = new List<TurmaAluno>();
}
