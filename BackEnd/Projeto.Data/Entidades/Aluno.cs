using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? UltimoNome { get; set; }

    public DateTime? Aniversario { get; set; }

    public string? Documento { get; set; }

    public string? Matricula { get; set; }

    public virtual ICollection<TurmaAluno> TurmaAlunos { get; } = new List<TurmaAluno>();
}
