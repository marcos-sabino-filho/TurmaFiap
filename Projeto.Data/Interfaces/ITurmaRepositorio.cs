using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface ITurmaRepositorio
    {
        List<Dto.TurmaDto> ListarTodas();
    }
}
