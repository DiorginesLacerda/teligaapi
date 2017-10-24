using AquiVoto.Common.Consts;
using AquiVoto.DataModels;
using AquiVoto.Models;
using AquiVoto.Repositories;
using AquiVoto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Services
{
    public class PostService : IPostService
    {
        private PostRepository _postRepository = new PostRepository();

        public bool Criar(Post entity)
        {
            return _postRepository.Criar(entity);
        }

        public bool Atualizar(Post entity)
        {
            return _postRepository.Atualizar(entity);
        }

        public List<PostModelList> ListarNovosModels()
        {
            return _postRepository.ListarNovos();
        }        

        public List<PostModelList> ListarAprovadosModels()
        {
            return _postRepository.ListarAprovados();
        }

        public List<PostModelList> ListarRepetidosModels()
        {
            return _postRepository.ListarRepetidos();
        }

        public List<PostModelList> ListarNegadosModels()
        {
            return _postRepository.ListarNegados();
        }

        public bool Excluir(long id)
        {
            return _postRepository.Excluir(id);
        }

        public Post BuscarPorId(long id)
        {
            return _postRepository.BuscarPorId(id);
        }

        public Post BuscarPorGuid(string guid)
        {
            return _postRepository.BuscarPorGuid(guid);
        }

        public PostModelCadastro Parse_EntityToModel(Post postEntity)
        {
            PostModelCadastro model = new PostModelCadastro();
            model.Post_Id = postEntity.Post_Id;
            model.Guid = postEntity.Guid;
            model.Local = postEntity.Local;
            model.Titulo = postEntity.Titulo;
            model.Usuario_Id = postEntity.Usuario_Id;
            model.Descricao = postEntity.Descricao;
            model.Aberto_ao_Publico = postEntity.Aberto_ao_Publico;
            model.Data_Votacao = postEntity.Data_Votacao;
            model.Data_Criacao = postEntity.Data_Criacao;
            model.Data_Alteracao = postEntity.Data_Alteracao;
            model.Post_Semelhante_Repetido = postEntity.Post_Semelhante_Repetido;
            model.Status_Post = postEntity.Status_Post;
            model.Observacao_Moderador = postEntity.Observacao_Moderador;

            return model;
        }

        public void SetPostAprovado(Post post)
        {
            post.Status_Post = ConstantesStatus.POST_APROVADO;
            post.Data_Alteracao = DateTime.Now;
        }

        public void SetPostRepetido(Post post, short leiRepetida, string observacaoModerador)
        {
            post.Status_Post = ConstantesStatus.POST_REPETIDO;
            post.Post_Semelhante_Repetido = leiRepetida;
            post.Observacao_Moderador = observacaoModerador;
            post.Data_Alteracao = DateTime.Now;
        }

        public void SetPostNegado(Post post, string observacaoModerador)
        {
            post.Status_Post = ConstantesStatus.POST_NEGADO;
            post.Observacao_Moderador = observacaoModerador;
            post.Data_Alteracao = DateTime.Now;
        }

        public List<Post> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
