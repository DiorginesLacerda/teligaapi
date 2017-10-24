using AquiVoto.Common.Consts;
using AquiVoto.DataModels;
using AquiVoto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Repositories
{
    public class PostRepository
    {
        public bool Criar(Post entity)
        {
            if (entity == null)
                return false;

            try
            {
                using (var ctx = new DatabaseContext())
                {
                    using (var dbTransaction = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            ctx.Posts.Add(entity);
                            ctx.SaveChanges();
                            dbTransaction.Commit();

                            return true;
                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Atualizar(Post entity)
        {
            if (entity == null)
                return false;

            try
            {
                using (var ctx = new DatabaseContext())
                {
                    using (var dbTransaction = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var achouPost = BuscarPorId(entity.Post_Id, ctx);

                            if (achouPost == null)
                                return false;

                            //substitui o antigo registro com os novos dados.
                            ctx.Entry(achouPost).CurrentValues.SetValues(entity);

                            ctx.SaveChanges();
                            dbTransaction.Commit();

                            return true;
                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PostModelList> ListarNovos()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var lista = (from p in ctx.Posts.ToList()
                                 where p.Status_Post == ConstantesStatus.NOVO_POST
                                 select new PostModelList()
                                 {
                                     Post_Id = p.Post_Id,
                                     Guid = p.Guid,
                                     Data_Votacao = p.Data_Votacao,
                                     Titulo = p.Titulo
                                 }).OrderByDescending(f => f.Data_Votacao).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PostModelList> ListarAprovados()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var lista = (from p in ctx.Posts.ToList()
                                 where p.Status_Post == ConstantesStatus.POST_APROVADO
                                 select new PostModelList()
                                 {
                                     Post_Id = p.Post_Id,
                                     Guid = p.Guid,
                                     Data_Votacao = p.Data_Votacao,
                                     Titulo = p.Titulo,
                                     Status_Post = p.Status_Post,
                                     Post_Semelhante_Repetido = p.Post_Semelhante_Repetido
                                 }).OrderByDescending(f => f.Data_Votacao).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PostModelList> ListarRepetidos()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var lista = (from p in ctx.Posts.ToList()
                                 where p.Status_Post == ConstantesStatus.POST_REPETIDO
                                 select new PostModelList()
                                 {
                                     Post_Id = p.Post_Id,
                                     Guid = p.Guid,
                                     Data_Votacao = p.Data_Votacao,
                                     Titulo = p.Titulo,
                                     Status_Post = p.Status_Post,
                                     Post_Semelhante_Repetido = p.Post_Semelhante_Repetido
                                 }).OrderByDescending(f => f.Data_Votacao).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PostModelList> ListarNegados()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var lista = (from p in ctx.Posts.ToList()
                                 where p.Status_Post == ConstantesStatus.POST_NEGADO
                                 select new PostModelList()
                                 {
                                     Post_Id = p.Post_Id,
                                     Guid = p.Guid,
                                     Data_Votacao = p.Data_Votacao,
                                     Titulo = p.Titulo,
                                     Status_Post = p.Status_Post,
                                     Post_Semelhante_Repetido = p.Post_Semelhante_Repetido
                                 }).OrderByDescending(f => f.Data_Votacao).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Excluir(long id)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Post BuscarPorId(long id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var match = ctx.Posts.Where(f => f.Post_Id == id).FirstOrDefault();

                    return match;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Post BuscarPorId(long id, DatabaseContext ctx)
        {
            var match = ctx.Posts.Where(f => f.Post_Id == id).FirstOrDefault();

            return match;
        }

        public Post BuscarPorGuid(string guid)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var match = ctx.Posts.Where(f => f.Guid == guid).FirstOrDefault();

                    return match;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
