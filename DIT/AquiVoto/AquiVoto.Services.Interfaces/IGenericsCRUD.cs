using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Services.Interfaces
{
    public interface IGenericsCRUD<T> where T : class
    {
        bool Criar(T entity);

        bool Atualizar(T entity);

        List<T> Listar();

        bool Excluir(long id);

        T BuscarPorId(long id);
    }
}
