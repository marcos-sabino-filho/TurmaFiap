using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class TurmaAluno
{
    public int IdTurma { get; set; }

    public int IdAluno { get; set; }

    public DateTime? PeriodoInicio { get; set; }

    public DateTime? PeriodoFim { get; set; }

    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    public virtual Turma IdTurmaNavigation { get; set; } = null!;
}
