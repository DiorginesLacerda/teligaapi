using AquiVoto.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Services.Interfaces
{
    public interface IUsuarioService : IGenericsCRUD<Usuario>
    {
        Usuario ChecarAutenticacao(string email, string senha);
    }
}
