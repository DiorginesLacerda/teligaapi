using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AquiVoto.DataModels;
using AquiVoto.Services;
using AquiVoto.Services.Interfaces;

namespace AquiVoto.App
{
    public class PostApi : ApiController
    {
        private readonly IPostService _postService;

        public PostApi(PostService postService)
        {
            _postService = postService;
        }


        // GET api/<controller>
        public List<Post> GetList()
        {
            return _postService.Listar();
        }

        // GET api/<controller>/5
        public Post Get(int id)
        {
            return _postService.BuscarPorId(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Post post)
        {
            return _postService.Criar(post);

        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]Post post)
        {
            return _postService.Atualizar(post);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return _postService.Excluir(id);
        }
    }
}
