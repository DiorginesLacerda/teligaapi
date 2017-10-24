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
    public class AutenticacaoController : Controller
    {
        private UsuarioService _usuarioService = new UsuarioService();

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login()
        {
            UsuarioModel model = new UsuarioModel();

            model.EstadosList = GlobalLocation.GetStates("Brazil");
            model.CidadesList = GlobalLocation.GetCities_BRA("RS");

            return View(model);
        }

        public ActionResult Autenticar(UsuarioModel usuarioModel)
        {
            try
            {
                //passa para objeto de entidade.
                var entity = _usuarioService.ParseToEntity(usuarioModel);

                //verifica se o usuario existe.
                var usuarioAutenticado = _usuarioService.ChecarAutenticacao(entity);

                if (usuarioAutenticado == null)
                {
                    return Json(new
                    {
                        message = "Usuário não encontrado",
                        result = "ERRO",
                        url = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    message = "Usuário encontrado",
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
