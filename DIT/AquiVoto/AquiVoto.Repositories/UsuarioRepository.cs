using AquiVoto.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Repositories
{
    public class UsuarioRepository
    {
        public bool Criar(Usuario entity)
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
                            ctx.Usuarios.Add(entity);
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

        public bool Editar(Usuario entity)
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
                            var achouUsuario = BuscarPorId(entity.Usuario_Id, ctx);

                            if (achouUsuario == null)
                                return false;

                            //substitui o antigo registro com os novos dados.
                            ctx.Entry(achouUsuario).CurrentValues.SetValues(entity);

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

        public List<Usuario> Listar()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var lista = ctx.Usuarios.OrderByDescending(f => f.Data_Alteracao).ToList();

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

        public Usuario BuscarPorId(long id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var match = ctx.Usuarios.Where(f => f.Usuario_Id == id).FirstOrDefault();

                    return match;
                }
            }
            catch (Exception)
            {
                return null;
            }            
        }

        private Usuario BuscarPorId(long id, DatabaseContext ctx)
        {
            var match = ctx.Usuarios.Where(f => f.Usuario_Id == id).FirstOrDefault();            

            return match;
        }

        public Usuario ChecarAutenticacao(Usuario entity)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var match = ctx.Usuarios.Where(f => (f.Email == entity.Email)
                                                      && (f.Senha == entity.Senha)
                                                      && (f.Ativo == 1))
                                                      .FirstOrDefault();
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
