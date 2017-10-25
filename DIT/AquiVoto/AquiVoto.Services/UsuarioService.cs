using AquiVoto.Common;
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
    public class UsuarioService : IUsuarioService
    {
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public bool Criar(Usuario entity)
        {
            SetNovo(entity);

            return _usuarioRepository.Criar(entity);
        }

        public bool Atualizar(Usuario entity)
        {
            SetAtualizar(entity);

            return _usuarioRepository.Editar(entity);
        }

        public List<Usuario> Listar()
        {
            return _usuarioRepository.Listar();
        }

        public bool Excluir(long id)
        {
            return _usuarioRepository.Excluir(id);
        }

        public Usuario BuscarPorId(long id)
        {
            return _usuarioRepository.BuscarPorId(id);
        }

        public Usuario ParseToEntity(UsuarioModel model)
        {
            Usuario entity = new Usuario();
            entity.Usuario_Id = model.Usuario_Id;
            entity.Nome = model.Nome;
            entity.Guid = model.Guid;
            entity.Estado = model.Estado;
            entity.Cidade = model.Cidade;
            entity.Email = model.Email;
            entity.Senha = model.Senha;
            entity.Ativo = model.Ativo;
            entity.Tipo_Cadastro = model.Tipo_Cadastro_Id;
            entity.Data_Cadastro = model.Data_Cadastro;
            entity.Data_Alteracao = model.Data_Alteracao;

            return entity;
        }

        public void SetNovo(Usuario entity)
        {
            entity.Guid = Guid.NewGuid().ToString();
            entity.Ativo = 1;
            entity.Tipo_Cadastro = 1;
            entity.Data_Cadastro = DateTime.Now;
            entity.Data_Alteracao = DateTime.Now;

            //criptografa a senha.
            entity.Senha = Encrypt.GenerateSHA256String(entity.Senha);
        }

        public void SetAtualizar(Usuario entity)
        {
            entity.Data_Alteracao = DateTime.Now;
        }

        public Usuario ChecarAutenticacao(string email, string senha)
        {
            return _usuarioRepository.ChecarAutenticacao(email, senha);
        }
    }
}
