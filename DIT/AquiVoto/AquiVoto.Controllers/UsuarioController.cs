using AquiVoto.Common;
using AquiVoto.Models;
using AquiVoto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AquiVoto.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioService _usuarioService = new UsuarioService();

        public ActionResult Cadastro()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(UsuarioModel usuarioModel)
        {
            try
            {
                //passa para objeto de entidade.
                var entity = _usuarioService.ParseToEntity(usuarioModel);

                bool resultado = false;
                string mensagem = string.Empty;

                if (entity.Usuario_Id <= 0)
                {
                    resultado = _usuarioService.Criar(entity);
                    mensagem = "criado";
                }
                else
                {
                    resultado = _usuarioService.Atualizar(entity);
                    mensagem = "atualizado";
                }

                if (!resultado)
                    return MensagemDeErro();

                //salvar acesso em cookie.
                CookieConfiguration.Instance.SaveCookie(entity.Usuario_Id);

                return Json(new
                {
                    message = string.Format("Usuário {0} salvo com sucesso!", mensagem),
                    result = "OK",
                    url = "/Posts/Listagem/"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return MensagemDeErro();
            }
        }

        private ActionResult MensagemDeErro()
        {
            return Json(new
            {
                message = "Erro durante a operação. Tente mais tarde.",
                result = "ERRO",
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
