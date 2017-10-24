using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Models
{
    public class PaginacaoModel
    {
        public int Pagina_Atual { get; set; }

        public int Total_De_Registros { get; set; }

        public int Total_De_Paginas { get; set; }
    }
}
