using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AquiVoto.DataModels;
using AquiVoto.Services;
using AquiVoto.Services.Interfaces;


namespace AquiVoto.Api
{
    public class UsuarioApi : ApiController
    {
        private readonly IUsuarioService _usuarioService;
        

        public UsuarioApi(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // GET api/<controller>
        public List<Usuario> GetList()
        {
            return _usuarioService.Listar();
        }
        // GET api/<controller>/5
        public Usuario GetLogin(string email, string senha)
        {
            return _usuarioService.ChecarAutenticacao(email,senha);
        }

        // GET api/<controller>/5
        public Usuario Get(int id)
        {
            return _usuarioService.BuscarPorId(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Usuario usuario)
        {
            return _usuarioService.Criar(usuario);
            
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]Usuario usuario)
        {
            return _usuarioService.Atualizar(usuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return _usuarioService.Excluir(id);
        }
    }
}
