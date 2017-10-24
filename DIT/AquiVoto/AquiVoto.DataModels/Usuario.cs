namespace AquiVoto.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public long Usuario_Id { get; set; }

        public int Tipo_Cadastro { get; set; }

        public string Guid { get; set; }

        public string Nome { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime Data_Cadastro { get; set; }

        public DateTime Data_Alteracao { get; set; }

        public short Ativo { get; set; }
    }
}
