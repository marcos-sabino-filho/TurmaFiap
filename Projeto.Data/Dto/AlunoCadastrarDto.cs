using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Dto
{
    public class AlunoCadastrarDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string? UltimoNome { get; set; }

        public DateTime? Aniversario { get; set; }

        public string? Documento { get; set; }

        public string? Matricula { get; set; }
    }
}
