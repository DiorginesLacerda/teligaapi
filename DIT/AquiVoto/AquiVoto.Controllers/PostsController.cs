using AquiVoto.Common.Consts;
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
    public class PostsController : Controller
    {
        private PostService _postService = new PostService();

        public ActionResult Listagem(PostModelList model)
        {
            return View(model);
        }

        public ActionResult Respondidos(PostModelList model)
        {
            try
            {
                return View(model);
            }
            catch (Exception)
            {
                return MensagemDeErro();
            }
        }

        [HttpGet]
        [ValidateInput(false)]
        public PartialViewResult GetPostsAprovados()
        {
            try
            {
                PostModelList modelResult = new PostModelList();
                modelResult.PostsList = new List<PostModelList>();

                //carrrega a listagem.
                modelResult.PostsList = _postService.ListarAprovadosModels();

                return PartialView("PartialListagemAprovados", modelResult);
            }
            catch (Exception)
            {
                return PartialView("PartialListagemAprovados", null);
            }
        }

        [HttpGet]
        [ValidateInput(false)]
        public PartialViewResult GetPostsRepetidos()
        {
            try
            {
                PostModelList modelResult = new PostModelList();
                modelResult.PostsList = new List<PostModelList>();

                //carrrega a listagem.
                modelResult.PostsList = _postService.ListarRepetidosModels();

                return PartialView("PartialListagemRepetidos", modelResult);
            }
            catch (Exception)
            {
                return PartialView("PartialListagemRepetidos", null);
            }
        }

        [HttpGet]
        [ValidateInput(false)]
        public PartialViewResult GetPostsNegados()
        {
            try
            {
                PostModelList modelResult = new PostModelList();
                modelResult.PostsList = new List<PostModelList>();

                //carrrega a listagem.
                modelResult.PostsList = _postService.ListarNegadosModels();

                return PartialView("PartialListagemNegados", modelResult);
            }
            catch (Exception)
            {
                return PartialView("PartialListagemNegados", null);
            }
        }

        [HttpGet]
        [ValidateInput(false)]
        public PartialViewResult GetPosts()
        {
            try
            {
                PostModelList modelResult = new PostModelList();
                modelResult.PostsList = new List<PostModelList>();

                //carrrega a listagem.
                modelResult.PostsList = _postService.ListarNovosModels();

                return PartialView("PartialListagem", modelResult);
            }
            catch (Exception)
            {
                return PartialView("PartialListagem", null);
            }
        }

        public ActionResult Cadastro(string id) //guid
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return RedirectToAction("Listagem");

                var postEntity = _postService.BuscarPorGuid(id);

                if (postEntity == null)
                {
                    return Json(new
                    {
                        message = "Post não encontrado para realizar a operação. Tente mais tarde.",
                        result = "ERRO",
                    }, JsonRequestBehavior.AllowGet);
                }

                PostModelCadastro model = new PostModelCadastro();

                if (postEntity != null)
                    model = _postService.Parse_EntityToModel(postEntity);

                if (model.Status_Post != ConstantesStatus.NOVO_POST)
                    model.Bloquear_Botoes_De_Acoes = true;

                return View(model);
            }
            catch (Exception)
            {
                return MensagemDeErro();
            }
        }

        public ActionResult Posts()
        {
            return View();
        }

        public ActionResult SalvarAprovarPost(string guid)
        {
            try
            {
                if (string.IsNullOrEmpty(guid))
                    return View();

                var postEntity = _postService.BuscarPorGuid(guid);

                if (postEntity == null)
                {
                    return Json(new
                   {
                       message = "Post não encontrado para realizar a operação. Tente mais tarde.",
                       result = "ERRO",
                   }, JsonRequestBehavior.AllowGet);
                }

                _postService.SetPostAprovado(postEntity);

                bool resultado = _postService.Atualizar(postEntity);

                if (resultado)
                {
                    return Json(new
                    {
                        message = "Post aprovado com sucesso!",
                        result = "OK",
                    }, JsonRequestBehavior.AllowGet);
                }

                return MensagemDeErro();
            }
            catch (Exception)
            {
                return MensagemDeErro();
            }
        }

        public ActionResult SalvarPostRepetido(string guid, short leiRepetida, string observacaoModerador)
        {
            try
            {
                if (string.IsNullOrEmpty(guid))
                    return View();

                var postEntity = _postService.BuscarPorGuid(guid);

                if (postEntity == null)
                {
                    return Json(new
                    {
                        message = "Post não encontrado para realizar a operação. Tente mais tarde.",
                        result = "ERRO",
                    }, JsonRequestBehavior.AllowGet);
                }

                _postService.SetPostRepetido(postEntity, leiRepetida, observacaoModerador);

                bool resultado = _postService.Atualizar(postEntity);

                if (resultado)
                {
                    return Json(new
                    {
                        message = "Post salva como repetida com sucesso!",
                        result = "OK",
                    }, JsonRequestBehavior.AllowGet);
                }

                return MensagemDeErro();
            }
            catch (Exception)
            {
                return MensagemDeErro();
            }
        }

        public ActionResult SalvarNegarPost(string guid, string observacaoModerador)
        {
            try
            {
                if (string.IsNullOrEmpty(guid))
                    return View();

                var postEntity = _postService.BuscarPorGuid(guid);

                if (postEntity == null)
                {
                    return Json(new
                    {
                        message = "Post não encontrado para realizar a operação. Tente mais tarde.",
                        result = "ERRO",
                    }, JsonRequestBehavior.AllowGet);
                }

                _postService.SetPostNegado(postEntity, observacaoModerador);

                bool resultado = _postService.Atualizar(postEntity);

                if (resultado)
                {
                    return Json(new
                    {
                        message = "Post negado com sucesso!",
                        result = "OK",
                    }, JsonRequestBehavior.AllowGet);
                }

                return MensagemDeErro();
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
