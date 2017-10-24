using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Models
{
    public class PostModelCadastro
    {
        public long Post_Id { get; set; }

        public long? Usuario_Id { get; set; }

        public string Guid { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public short? Aberto_ao_Publico { get; set; }

        public string Local { get; set; }

        public string Status_Post { get; set; }

        public DateTime? Data_Votacao { get; set; }

        public DateTime Data_Criacao { get; set; }

        public DateTime Data_Alteracao { get; set; }

        public short Post_Semelhante_Repetido { get; set; }

        public bool Bloquear_Botoes_De_Acoes { get; set; }

        public string Observacao_Moderador { get; set; }
    }
}
