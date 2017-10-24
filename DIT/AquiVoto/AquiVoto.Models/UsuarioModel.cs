using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AquiVoto.Models
{
    public class UsuarioModel
    {
        public long Usuario_Id { get; set; }

        public int Tipo_Cadastro_Id { get; set; }

        public string Guid { get; set; }

        public string Nome { get; set; }

        public string Nome_Social { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Senha_Repetida { get; set; }

        public short Ativo { get; set; }

        public DateTime Data_Cadastro { get; set; }

        public DateTime Data_Alteracao { get; set; }

        public List<SelectListItem> EstadosList { get; set; }

        public List<SelectListItem> CidadesList { get; set; }

        public string Email_Logar { get; set; }

        public string Senha_Logar { get; set; }
    }
}
